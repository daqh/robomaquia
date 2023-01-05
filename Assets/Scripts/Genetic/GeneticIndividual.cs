using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticIndividual : MonoBehaviour
{

    [SerializeField]
    private CharacterFactoryService.Avatar avatar;

    [SerializeField]
    private WeaponService.Weapon weapon;

    [SerializeField]
    private float velocityMultiplier = 1f;

    public float Fitness {
        get {
            return 0;
        } 
    }

    public CharacterFactoryService.Avatar Avatar {
        get {
            return avatar;
        }
    }

    public WeaponService.Weapon Weapon {
        get {
            return weapon;
        }
    }

    public float VelocityMultiplier {
        get {
            return velocityMultiplier;
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


}
