using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof (CharacterController))]
public class AgentController : MonoBehaviour
{

    [SerializeField]
    [Range(0, 2)]
    private float fieldOfViewRadius = 1;

    [SerializeField]
    [Range(0, 2)]
    private float fieldOfAttackRadius = 1;

    private void Start() {

    }

    private void Update() {

    }

    void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position + transform.up * fieldOfViewRadius, transform.position + transform.right * fieldOfViewRadius, Color.blue);
        Debug.DrawLine(transform.position + transform.right * fieldOfViewRadius, transform.position - transform.up * fieldOfViewRadius, Color.blue);
        Debug.DrawLine(transform.position - transform.up * fieldOfViewRadius, transform.position - transform.right * fieldOfViewRadius, Color.blue);
        Debug.DrawLine(transform.position - transform.right * fieldOfViewRadius, transform.position + transform.up * fieldOfViewRadius, Color.blue);

        Debug.DrawLine(transform.position + transform.up * fieldOfAttackRadius, transform.position + transform.right * fieldOfAttackRadius, Color.red);
        Debug.DrawLine(transform.position + transform.right * fieldOfAttackRadius, transform.position - transform.up * fieldOfAttackRadius, Color.red);
        Debug.DrawLine(transform.position - transform.up * fieldOfAttackRadius, transform.position - transform.right * fieldOfAttackRadius, Color.red);
        Debug.DrawLine(transform.position - transform.right * fieldOfAttackRadius, transform.position + transform.up * fieldOfAttackRadius, Color.red);
    }

}
