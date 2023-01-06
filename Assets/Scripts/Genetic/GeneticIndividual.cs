using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GeneticIndividual : MonoBehaviour
{

    [SerializeField]
    private CharacterFactoryService.Avatar avatar;

    [SerializeField]
    private WeaponService.Weapon weapon;

    [SerializeField]
    private float velocityMultiplier = 1f;

    public void OnUseWeapon(Vector2 position) {
        usages++;
    }

    public void OnDamage(int damage) {
        hits++;
        totalDamage += damage;
    }

    public void Start() {
        this.characterFactory.CharacterWeaponController.OnUseWeapon += OnUseWeapon;
        this.characterFactory.CharacterWeaponController.OnDamage += OnDamage;
        this.agentController = this.characterFactory.gameObject.GetComponent<AgentController>();
    }

    public void Update() {
        if(characterFactory != null) {
            if(Vector2.Distance(characterFactory.transform.position, agentController.Player.transform.position) < agentController.FieldOfViewRadius) {
                lifespan += Time.deltaTime;
            }
        } 
    }


    private float lifespanWeight = 1f;
    private float lifespan = 0f;
    private float totalDamageWeight = 1f;
    private float precisionWeight = 1f;

    public float Fitness {
        get {
            return lifespan * lifespanWeight + totalDamage * totalDamageWeight + Precision * precisionWeight;
        } 
    }

    public CharacterFactoryService.Avatar Avatar {
        get {
            return avatar;
        }
        set {
            avatar = value;
        }
    }

    public WeaponService.Weapon Weapon {
        get {
            return weapon;
        }
        set {
            weapon = value;
        }
    }

    public float VelocityMultiplier {
        get {
            return velocityMultiplier;
        }
        set {
            velocityMultiplier = value;
        }
    }

    [SerializeField]
    private CharacterFactory characterFactory; 

    public CharacterFactory CharacterFactory {
        get {
            return characterFactory;
        }
        set {
            characterFactory = value;
        }
    }

    public float Lifespan {
        get {
            return lifespan;
        }
    }

    public float Precision {
        get {
            if(usages > 0) return hits / (float)usages;
            return 0;
        }
    }

    private int usages = 0;
    private int totalDamage = 0;
    private int hits = 0;

    private AgentController agentController;

    #if UNITY_EDITOR
    private void OnDrawGizmos() {
        if(characterFactory != null) {
            Handles.Label(characterFactory.transform.position + transform.up, Fitness.ToString());
        }
    }
    #endif

}
