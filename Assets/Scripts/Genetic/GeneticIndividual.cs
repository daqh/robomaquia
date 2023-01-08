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
    private Coin coin;

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

    private bool beenAlive = false;
    private Vector2 lastPosition;

    public void Update() {
        if(characterFactory != null) {
            beenAlive = true;
            lastPosition = characterFactory.transform.position;
            if(Vector2.Distance(characterFactory.transform.position, agentController.Player.transform.position) < agentController.FieldOfAttackRadius) {
                lifespan += Time.deltaTime;
            }
        } else {
            if(beenAlive) {
                OnDeath();
                beenAlive = false;
            }
        }
    }

    private void OnDeath()
    {
        for (int i = 0; i < Mathf.Log(Fitness, 2); i++)
        {
            Coin c = Instantiate(coin, lastPosition, Quaternion.identity);
            c.Rigidbody2D.AddForce(new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)).normalized * Random.Range(10, 350));
        }
    }

    private float lifespanWeight = 1f;
    private float lifespan = 0f;
    private float totalDamageWeight = 1.5f;
    private float precisionWeight = 25f;

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

    public Coin Coin {
        get {
            return coin;
        }
        set {
            coin = value;
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

    public int TotalDamage {
        get {
            return totalDamage;
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
