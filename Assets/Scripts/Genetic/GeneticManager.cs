using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticManager : MonoBehaviour
{

    [SerializeField]
    private CharacterFactory characterFactory;

    private List<GeneticSpawnPoint> spawnPoints = new List<GeneticSpawnPoint>();

    [SerializeField]
    private List<GeneticIndividual> initialPopulation = new List<GeneticIndividual>();

    [SerializeField]
    private Coin coin;

    private int generationCount = 0;

    private void Awake() {
        characterFactoryService = GetComponent<CharacterFactoryService>();
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
        bool generationEnd = true;
        foreach(GeneticIndividual individual in this.population) {
            if(individual.CharacterFactory != null) {
                generationEnd = false;
            }
        }
        if(generationEnd) {
            float totalFitness = 0;
            float maxFitness = 0;
            float avgFitness = 0;
            float minFitness = this.population[0].Fitness;
            foreach(GeneticIndividual gi in this.population) {
                totalFitness += gi.Fitness;
                avgFitness += gi.Fitness / this.population.Count;
                if(maxFitness < gi.Fitness) maxFitness = gi.Fitness;
                if(minFitness > gi.Fitness) minFitness = gi.Fitness;
                Destroy(gi.gameObject);
            }
            Debug.Log("End of generation " + generationCount + " / AvgFitness = " + avgFitness + " / MaxFitness = " + maxFitness + " / MinFitness = " + minFitness + " / TotalFitness = " + totalFitness);
            List<GeneticIndividual> nextPopulation = new List<GeneticIndividual>();
            this.population.Sort(SortByLifespanDescending);
            nextPopulation.Add(this.population[0]); // Elitismo di un individuo con lifespan migliore
            this.population.RemoveAt(0);
            this.population.Sort(SortByFitnessDescending);
            for(int i = 0; i < Mathf.Floor((this.population.Count / 100f) * 55f); i++) {    // Selezione del 66% dei migliori individui (Escluso l'individuo elitario)
                nextPopulation.Add(this.population[i]);
            }
            // Crossover
            int nCrossover = this.population.Count - nextPopulation.Count + 1;
            for(int i = 0; i <= nCrossover; i++) {
                GameObject go = new GameObject("Crossover " + i);
                GeneticIndividual gi = go.AddComponent<GeneticIndividual>();
                gi.Coin = coin;
                gi.Avatar = this.population[i].Avatar;
                gi.Weapon = this.population[i + 1].Weapon;
                gi.VelocityMultiplier = this.population[i + 1].VelocityMultiplier;
                Destroy(go);
                nextPopulation.Add(gi);
            }
            // Mutation
            foreach(GeneticIndividual individual in this.population) {
                individual.VelocityMultiplier += Random.Range(-3f, 3f);
                // individual.Avatar = characterFactoryService.GetRandomCharcter();
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

}
