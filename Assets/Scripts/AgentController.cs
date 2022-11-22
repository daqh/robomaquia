using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterManager))]
public class AgentController : MonoBehaviour
{

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float minDistanceFromTarget = 0.5f;

    private CharacterManager characterManager;

    void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
    }

    void Update()
    {
        float distance = Vector3.Distance (target.transform.position, transform.position);
        if(distance > minDistanceFromTarget) {
            Vector2 p = target.transform.position - transform.position;
            if(p.x < 0) {
                characterManager.FlipController.WatchLeft();
            }
            if(p.x > 0) {
                characterManager.FlipController.WatchRight();
            }
            characterManager.RunController.Run(p);
        }
    }
}
