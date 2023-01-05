using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticSpawnPoint : MonoBehaviour
{

    public GeneticIndividual Instantiate(GeneticIndividual geneticIndividual) {
        GameObject go = Instantiate(geneticIndividual.gameObject, transform.position, Quaternion.identity);
        return go.GetComponent<GeneticIndividual>();
    }

}
