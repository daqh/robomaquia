using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Genetic {
    public class GeneticManager : MonoBehaviour
    {

        [SerializeField]
        private GeneticIndividual[] population;

        private List<GeneticSpawnPoint> spawnPoints = new List<GeneticSpawnPoint>();

        public void Start() {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Genetic Spawn Point");
            foreach(GameObject o in gameObjects) {
                spawnPoints.Add(o.GetComponent<GeneticSpawnPoint>());
            }
            Populate();
        }

        private void Populate() {
            int i = 0;
            foreach(GeneticIndividual individual in population) {
                GeneticSpawnPoint spawnPoint;
                do {
                    spawnPoint = spawnPoints[i++ % spawnPoints.Count];
                } while(!spawnPoint.Enabled);
                spawnPoint.Instantiate(individual);
            }
        }

    }
}
