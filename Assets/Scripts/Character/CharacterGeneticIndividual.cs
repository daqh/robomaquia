using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Genetic;

[RequireComponent(typeof(CharacterStats))]
public class CharacterGeneticIndividual : GeneticIndividual
{

    private CharacterStats characterStats;

    private void Start() {
        characterStats = GetComponent<CharacterStats>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Q) && gameObject.tag == "Player") {
            Debug.Log(Fitness);
        }
    }

    public override float Fitness {
        get {
            return characterStats.Precision + characterStats.Lifespan;
        }
    }

    void OnDrawGizmos()
    {
        if(characterStats) {
            Handles.Label(transform.position, "F: " + Fitness.ToString());
        }
    }

}
