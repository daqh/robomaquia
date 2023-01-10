using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactoryService : MonoBehaviour
{

    [SerializeField]
    private GameObject knightM;
    [SerializeField]
    private GameObject knightF;
    [SerializeField]
    private GameObject bigDemon;
    [SerializeField]
    private GameObject bigZombie;
    [SerializeField]
    private GameObject iceZombie;
    [SerializeField]
    private GameObject orc;
    [SerializeField]
    private GameObject chort;
    [SerializeField]
    private GameObject lizard;
    [SerializeField]
    private GameObject necromancer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public Avatar GetRandomCharacter() {
        Avatar avatar = (Avatar)Random.Range(2, 9);
        return avatar;
    }

    public GameObject GetCharacter(Avatar avatar) {
        switch(avatar) {
            case Avatar.KnightM:
                return knightM;
            case Avatar.KnightF:
                return knightF;
            case Avatar.BigDemon:
                return bigDemon;
            case Avatar.BigZombie:
                return bigZombie;
            case Avatar.IceZombie:
                return iceZombie;
            case Avatar.Orc:
                return orc;
            case Avatar.Chort:
                return chort;
            case Avatar.Lizard:
                return lizard;
            case Avatar.Necromancer:
                return necromancer;
        }
        return null;
    }

    public enum Avatar
    {
        KnightM,
        KnightF,
        BigDemon,
        BigZombie,
        IceZombie,
        Orc,
        Chort,
        Lizard,
        Necromancer
    }

}
