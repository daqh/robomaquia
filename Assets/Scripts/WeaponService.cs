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

    [SerializeField]
    private MeleeWeapon cleaver;

    [SerializeField]
    private MeleeWeapon knife;

    [SerializeField]
    private MeleeWeapon redMagicStaff;

    public enum Weapon
    {
        AnimeSword,
        Axe,
        BatonWithSpikes,
        BigHammer,
        DuelSword,
        Machete,
        Cleaver,
        Knife,
        RedMagicStaff
    }


    public Weapon GetRandomWeapon() {
        Weapon weapon = (Weapon)Random.Range(0, 9);
        return weapon;
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
            case Weapon.Cleaver:
                return cleaver;
            case Weapon.Knife:
                return knife;
            case Weapon.RedMagicStaff:
                return redMagicStaff;
        }
        return null;
    }
}
