using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponService : MonoBehaviour
{
    [SerializeField]
    private MeleeWeapon animeSword;

    [SerializeField]
    private MeleeWeapon axe;

    [SerializeField]
    private MeleeWeapon batonWithSpikes;

    [SerializeField]
    private MeleeWeapon bigHammer;

    [SerializeField]
    private MeleeWeapon duelSword;

    [SerializeField]
    private MeleeWeapon machete;

    public enum Weapon
    {
        AnimeSword,
        Axe,
        BatonWithSpikes,
        BigHammer,
        DuelSword,
        Machete
    }

    public MeleeWeapon GetMeleeWeapon(Weapon weapon)
    {
        switch (weapon)
        {
            case Weapon.AnimeSword:
                return animeSword;
            case Weapon.Axe:
                return axe;
            case Weapon.BatonWithSpikes:
                return batonWithSpikes;
            case Weapon.BigHammer:
                return bigHammer;
            case Weapon.DuelSword:
                return duelSword;
            case Weapon.Machete:
                return machete;
        }
        return null;
    }
}
