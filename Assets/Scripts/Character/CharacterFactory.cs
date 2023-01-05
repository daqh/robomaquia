using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{

    [SerializeField]
    private CharacterFactoryService.Avatar avatar = CharacterFactoryService.Avatar.KnightM;

    [SerializeField]
    private WeaponService.Weapon weapon = WeaponService.Weapon.AnimeSword;

    [SerializeField]
    private GameObject effectiveCharacter;

    [SerializeField]
    private HealthBar healthBar;

    private void Awake() {
        GameObject gameController = GameObject.FindWithTag("GameController");
        characterFactoryService = gameController.GetComponent<CharacterFactoryService>();
        weaponService = gameController.GetComponent<WeaponService>();
        GameObject effectiveCharacter = characterFactoryService.GetCharacter(avatar);
        Destroy(this.effectiveCharacter);
        this.effectiveCharacter = Instantiate(effectiveCharacter, transform);
        healthBar.HealthController = this.effectiveCharacter.GetComponent<HealthController>();
        this.effectiveCharacter.GetComponent<HealthController>().Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public GameObject EffectiveCharacter {
        get {
            return effectiveCharacter;
        }
    }

    public MeleeWeapon MeleeWeapon {
        get {
            return weaponService.GetMeleeWeapon(weapon);
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

    private CharacterFactoryService characterFactoryService;
    private WeaponService weaponService;

}
