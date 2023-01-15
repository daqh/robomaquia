using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Threading;
using TMPro;

public class GeneticManager : MonoBehaviour
{

    [SerializeField]
    private CharacterFactory characterFactory;

    private List<GeneticSpawnPoint> spawnPoints = new List<GeneticSpawnPoint>();

    [SerializeField]
    private List<GeneticIndividual> initialPopulation = new List<GeneticIndividual>();

    [SerializeField]
    private Coin coin;

    [SerializeField]
    private TMP_Text generationText;

    private int generationCount = 0;

    private DebugGUI debugGUI;

    private void Awake() {
        characterFactoryService = GetComponent<CharacterFactoryService>();
        weaponService = GetComponent<WeaponService>();
        debugGUI = GetComponent<DebugGUI>();
        DebugGUI.SetGraphProperties("maxFitness", "MAX Fitness", 0, 200, 0, Color.red, true);
        DebugGUI.SetGraphProperties("avgFitness", "AVG Fitness", 0, 100, 1, new Color(0, 1, 1), true);
        DebugGUI.SetGraphProperties("minFitness", "MIN Fitness", 0, 5, 2, Color.yellow, true);
        DebugGUI.SetGraphProperties("totalFitness", "TOTAL Fitness", 0, 200, 3, Color.green, true);
        DebugGUI.SetGraphProperties("rtMaxFitness", "MAX Fitness", 0, 0, 4, Color.red, true);
        DebugGUI.SetGraphProperties("rtAvgFitness", "AVG Fitness", 0, 0, 4, new Color(0, 1, 1), true);
        DebugGUI.SetGraphProperties("rtMinFitness", "MIN Fitness", 0, 0, 4, Color.yellow, true);
    }

    public void Start() {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Genetic Spawn Point");
        foreach(GameObject o in gameObjects) {
            spawnPoints.Add(o.GetComponent<GeneticSpawnPoint>());
        }
        Populate(initialPopulation);
    }

    private int SortByLifespanDescending(GeneticIndividual a, GeneticIndividual b) {
        return (int)Mathf.Ceil(b.Lifespan - a.Lifespan);
    }

    private int SortByFitnessDescending(GeneticIndividual a, GeneticIndividual b) {
        return (int)Mathf.Ceil(b.Lifespan - a.Lifespan);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.F1)) {
            debugGUI.DisplayGraphs = !debugGUI.DisplayGraphs;
            debugGUI.DisplayLogs = !debugGUI.DisplayLogs;
        }
        bool generationEnd = true;
        foreach(GeneticIndividual individual in this.population) {
            if(individual.CharacterFactory != null) {
                generationEnd = false;
            }
        }
        float totalFitness = 0;
        float maxFitness = 0;
        float avgFitness = 0;
        float minFitness = this.population[0].Fitness;
        //
        float maxLifespan = 0;
        float minLifespan = this.population[0].TotalDamage;
        int maxTotalDamage = 0;
        int minTotalDamage = this.population[0].TotalDamage;
        foreach(GeneticIndividual gi in this.population) {
            totalFitness += gi.Fitness;
            avgFitness += gi.Fitness / this.population.Count;
            if(maxFitness < gi.Fitness) maxFitness = gi.Fitness;
            if(minFitness > gi.Fitness) minFitness = gi.Fitness;
            if(maxTotalDamage < gi.TotalDamage) maxTotalDamage = gi.TotalDamage;
            if(minTotalDamage > gi.TotalDamage) minTotalDamage = gi.TotalDamage;
            if(maxLifespan < gi.Lifespan) maxLifespan = gi.Lifespan;
            if(minLifespan > gi.Lifespan) minLifespan = gi.Lifespan;
        }
        DebugGUI.LogPersistent("avgFitness", "AVG Fitness: " + avgFitness);
        DebugGUI.LogPersistent("maxFitness", "MAX Fitness: " + maxFitness);
        DebugGUI.LogPersistent("minFitness", "MIN Fitness: " + minFitness);
        DebugGUI.LogPersistent("totalFitness", "TOTAL Fitness: " + totalFitness);
        DebugGUI.Graph("rtMaxFitness", maxFitness);
        DebugGUI.Graph("rtMinFitness", minFitness);
        DebugGUI.Graph("rtAvgFitness", avgFitness);
        if(generationEnd) {
            for(int i = 0; i < 10; i++) {
                DebugGUI.Graph("avgFitness", avgFitness);
                DebugGUI.Graph("maxFitness", maxFitness);
                DebugGUI.Graph("minFitness", minFitness);
                DebugGUI.Graph("totalFitness", totalFitness);
            }
            foreach(GeneticIndividual gi in this.population) {
                Destroy(gi.gameObject);
            }
            Debug.Log("End of generation " + generationCount + " / AvgFitness = " + avgFitness + " / MaxFitness = " + maxFitness + " / MinFitness = " + minFitness + " / TotalFitness = " + totalFitness);
            List<GeneticIndividual> nextPopulation = new List<GeneticIndividual>();
            this.population.Sort(SortByLifespanDescending);
            nextPopulation.Add(this.population[0]); // Elitismo di un individuo con lifespan migliore
            this.population.RemoveAt(0);
            this.population.Sort(SortByFitnessDescending);
            List<GeneticIndividual> selectedIndividuals = new List<GeneticIndividual>();
            for(int i = 0; i < this.population.Count; i++) {    // Selezione del 66% dei migliori individui (Escluso l'individuo elitario)
                if(i < Mathf.Floor((this.population.Count / 100f) * 66f)) {
                    this.population[i].gameObject.name = "Selected Individual " + i + " (" + this.population[i].Avatar + ")";
                    nextPopulation.Add(this.population[i]);
                    selectedIndividuals.Add(this.population[i]);
                } else {
                    Destroy(this.population[i]);
                }
            }
            // Crossover
            int nCrossover = this.population.Count - nextPopulation.Count + 1;
            for(int i = 0; i <= nCrossover; i++) {
                GameObject go = new GameObject("Crossover Individual " + i);
                GeneticIndividual gi = go.AddComponent<GeneticIndividual>();
                gi.Coin = coin;
                gi.Avatar = this.population[i].Avatar;
                go.name = go.name + " (" + gi.Avatar + ")";
                gi.Weapon = this.population[i + 1].Weapon;
                gi.VelocityMultiplier = this.population[i + 1].VelocityMultiplier;
                Destroy(go);
                nextPopulation.Add(gi);
            }
            // Mutation
            for(int i = (int)Mathf.Floor((selectedIndividuals.Count / 100f) * 66f); i < selectedIndividuals.Count; i++) {    // Selezione del 66% dei migliori individui (Escluso l'individuo elitario)
                GeneticIndividual individual = selectedIndividuals[i];
                individual.gameObject.name = "Muted Individual " + i;
                float normalizedLifespan = maxLifespan == minLifespan ? 0 : ((individual.Lifespan - minLifespan)*1)/(maxLifespan-minLifespan);
                float normalizedTotalDamage = maxTotalDamage == minTotalDamage ? 0 : ((individual.TotalDamage - minTotalDamage)*1)/(maxTotalDamage-minTotalDamage);
                // Debug.Log(normalizedLifespan + " / " + normalizedTotalDamage + " / " + individual.TotalDamage + " / " + individual.Lifespan);
                individual.VelocityMultiplier += Random.Range(-1f, 1f);
                if(normalizedTotalDamage < normalizedLifespan) {
                    WeaponService.Weapon weapon = weaponService.GetRandomWeapon();
                    Debug.Log("Setting weapon " + weapon + " to " + individual);
                    individual.Weapon = weapon;
                } else {
                    CharacterFactoryService.Avatar avatar = characterFactoryService.GetRandomCharacter();
                    Debug.Log("Setting avatar " + avatar + " to " + individual);
                    individual.Avatar = avatar;
                }
                individual.gameObject.name = individual.gameObject.name + " (" + individual.Avatar + ")";
            }
            RespawnPlayer();
            Populate(nextPopulation);
            generationEnd = false;
        }
    }

    private void RespawnPlayer() {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = Vector2.zero;
        CharacterFactory cf = player.GetComponent<CharacterFactory>();
        cf.HealthController.ResetHealth();
    }

    private void Populate(List<GeneticIndividual> population) {
        Debug.Log("Begin of generation " + ++generationCount + "  / #population = " + population.Count);
        generationText.text = "STAGE " + generationCount;
        int i = 0;
        this.population = new List<GeneticIndividual>();
        foreach(GeneticIndividual individual in population) {
            GeneticSpawnPoint spawnPoint;
            spawnPoint = spawnPoints[i++ % spawnPoints.Count];
            this.population.Add(spawnPoint.Instantiate(individual, characterFactory));
        }
    }

    private List<GeneticIndividual> population = new List<GeneticIndividual>();
    private CharacterFactoryService characterFactoryService;
    private WeaponService weaponService;

}
