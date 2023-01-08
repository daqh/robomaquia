using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticSpawnPoint : MonoBehaviour
{

    public GeneticIndividual Instantiate(GeneticIndividual geneticIndividual, CharacterFactory characterFactory) {
        GameObject go = Instantiate(geneticIndividual.gameObject, transform.position, Quaternion.identity);
        characterFactory.Avatar = geneticIndividual.Avatar;
        characterFactory.Weapon = geneticIndividual.Weapon;
        characterFactory.VelocityMultiplier = geneticIndividual.VelocityMultiplier;
        GameObject character = Instantiate(characterFactory.gameObject, go.transform);
        GeneticIndividual gi = go.GetComponent<GeneticIndividual>();
        character.name = gi.name;
        gi.enabled = true;
        gi.CharacterFactory = character.GetComponent<CharacterFactory>();
        return gi;
    }

}
