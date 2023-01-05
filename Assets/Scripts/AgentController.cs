using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(MovementController2D))]
[RequireComponent(typeof(CharacterWeaponController))]
public class AgentController : MonoBehaviour
{

    [SerializeField]
    [Range(0, 2)]
    private float fieldOfViewRadius = 1;

    [SerializeField]
    [Range(0, 2)]
    private float fieldOfAttackRadius = 1;

    private GameObject player;

    private static Vector2 lastPlayerPosition;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
        movementController2D = GetComponent<MovementController2D>();
        characterWeaponController = GetComponent<CharacterWeaponController>();
    }

    private void Start() {

    }

    private void LateUpdate() {
        bool playerInFieldOfView = Vector2.Distance(player.transform.position, transform.position) < fieldOfViewRadius;
        bool playerInFieldOfAttack = Vector2.Distance(player.transform.position, transform.position) < fieldOfAttackRadius;
        if(playerInFieldOfView) {
            movementController2D.Move(player.transform.position - transform.position);
            lastPlayerPosition = player.transform.position;
        }
        if(playerInFieldOfAttack) {
            characterWeaponController.Use(player.transform.position);
        }
        if(!playerInFieldOfView && !playerInFieldOfAttack) {
            if(lastPlayerPosition != null) {
                movementController2D.Move(lastPlayerPosition - (Vector2)transform.position);
            }
        }
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

    private MovementController2D movementController2D;
    private CharacterWeaponController characterWeaponController;


}
