using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Genetic {
    public class GeneticSpawnPoint : MonoBehaviour
    {

        public GeneticIndividual Instantiate(GeneticIndividual individual) {
            return Instantiate(individual, transform.position, Quaternion.identity);
        }

    }
}
