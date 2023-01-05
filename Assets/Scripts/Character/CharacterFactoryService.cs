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

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public GameObject GetCharacter(Avatar avatar) {
        switch(avatar) {
            case Avatar.KnightM:
                return knightM;
            case Avatar.KnightF:
                return knightF;
            case Avatar.BigDemon:
                return bigDemon;
        }
        return null;
    }

    public enum Avatar
    {
        KnightM,
        KnightF,
        BigDemon,
    }

}
