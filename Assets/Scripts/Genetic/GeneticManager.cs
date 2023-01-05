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
            List<GeneticIndividual> nextPopulation = new List<GeneticIndividual>();
            this.population.Sort(SortByLifespanDescending);
            nextPopulation.Add(this.population[0]); // Elitismo di un individuo con lifespan migliore
            this.population.RemoveAt(0);
            this.population.Sort(SortByFitnessDescending);
            for(int i = 0; i < Mathf.Floor((this.population.Count / 100f) * 66f); i++) {    // Selezione del 66% dei migliori individui (Escluso l'individuo elitario)
                nextPopulation.Add(this.population[i]);
            }
            // Crossover
            Populate(nextPopulation);
            generationEnd = false;
        }
    }

    private void Populate(List<GeneticIndividual> population) {
        int i = 0;
        this.population = new List<GeneticIndividual>();
        foreach(GeneticIndividual individual in population) {
            GeneticSpawnPoint spawnPoint;
            spawnPoint = spawnPoints[i++ % spawnPoints.Count];
            this.population.Add(spawnPoint.Instantiate(individual, characterFactory));
        }
    }

    private List<GeneticIndividual> population = new List<GeneticIndividual>();

}
