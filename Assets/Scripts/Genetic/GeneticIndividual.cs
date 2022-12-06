using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Genetic {

    public abstract class GeneticIndividual : MonoBehaviour
    {

        public abstract float Fitness {
            get;
        }

    }

}

