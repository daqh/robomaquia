using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Genetic {
    public class GeneticSpawnPoint : MonoBehaviour
    {

        [SerializeField]
        private bool enabled;

        public GeneticIndividual Instantiate(GeneticIndividual individual) {
            return Instantiate(individual, transform.position, Quaternion.identity);
        }

        public bool Enabled {
            get {
                return enabled;
            }
            set {
                enabled = value;
            }
        }

    }
}
