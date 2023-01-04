using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Genetic;

[RequireComponent(typeof(CharacterStats))]
public class CharacterGeneticIndividual : GeneticIndividual
{

    private float precisionWeight = 1;

    private float lifespanWeight = 0.5f;

    private float damageWeight = 1;

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
            return characterStats.Precision * precisionWeight + characterStats.Lifespan * lifespanWeight + characterStats.Damage * damageWeight;
        }
    }

    void OnDrawGizmos()
    {
        if(characterStats) {
            Handles.Label(transform.position, "F: " + Fitness.ToString());
        }
    }

}
