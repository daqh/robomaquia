using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponController : MonoBehaviour
{

    private CharacterFactory characterFactory;

    private void Start()
    {
        characterFactory = GetComponent<CharacterFactory>();
    }

    public Action<Vector2> OnUseWeapon;

    public void Use(Vector2 position) {
        WeaponHolder weaponHolder = characterFactory.EffectiveCharacter.GetComponent<WeaponHolder>();
        OnUseWeapon?.Invoke(position);
        if(meleeWeapon) {
            if(!meleeWeapon.InUse) {
                Destroy(meleeWeapon.gameObject);
                meleeWeapon = Instantiate(characterFactory.MeleeWeapon, (Vector2)transform.position + weaponHolder.Offset * transform.localScale, Quaternion.identity);
                meleeWeapon.transform.localScale = transform.localScale;
                meleeWeapon.gameObject.transform.parent = transform;
                meleeWeapon.Use(position);
            }
        } else {
                meleeWeapon = Instantiate(characterFactory.MeleeWeapon, (Vector2)transform.position + weaponHolder.Offset * transform.localScale, Quaternion.identity);
                meleeWeapon.transform.localScale = transform.localScale;
                meleeWeapon.gameObject.transform.parent = transform;
                meleeWeapon.Use(position);
        }
    }

    private MeleeWeapon meleeWeapon;

}
