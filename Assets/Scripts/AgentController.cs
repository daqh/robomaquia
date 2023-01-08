using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using Pathfinding;

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

    private NavigationMap navigationMap;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
        movementController2D = GetComponent<MovementController2D>();
        characterWeaponController = GetComponent<CharacterWeaponController>();
        navigationMap = GameObject.FindWithTag("Navigation Map").GetComponent<NavigationMap>();
    }

    private NavigationPoint destination;

    private void Start() {
        destination = navigationMap.FindClosestPoint(transform.position);
    }

    private Vector2 playerPosition;

    private void LateUpdate() {
        bool playerInFieldOfView = Vector2.Distance(player.transform.position, transform.position) < fieldOfViewRadius;
        bool playerInFieldOfAttack = Vector2.Distance(player.transform.position, transform.position) < fieldOfAttackRadius;
        if(playerInFieldOfAttack) {
            if(player.transform.position.y < transform.position.y) {
                Debug.DrawLine(transform.position, player.transform.position, Color.green);
                movementController2D.Move(player.transform.position - transform.position);
            }
            characterWeaponController.Use(player.transform.position);
        } else if(playerInFieldOfView) {
            Debug.DrawLine(transform.position, player.transform.position, Color.green);
            movementController2D.Move(player.transform.position - transform.position);
        } else {
            if(Vector2.Distance(transform.position, destination.transform.position) > 0.2f) {
                movementController2D.Move(destination.transform.position - transform.position);
                Debug.DrawLine(transform.position, destination.transform.position, Color.green);
            } else {
                destination = navigationMap.FindNextPoint(destination, this);
            }
        }
        // bool playerInFieldOfAttack = Vector2.Distance(player.transform.position, transform.position) < fieldOfAttackRadius;
        // if(playerInFieldOfView) {
        //     if(Vector2.Distance(player.transform.position, transform.position) < 0.3f) {
        //         movementController2D.Move(-player.transform.position + transform.position);
        //     } else {
        //         movementController2D.Move(player.transform.position - transform.position);
        //     }
        //     lastPlayerPosition = player.transform.position;
        // }
        // if(playerInFieldOfAttack) {
        //     characterWeaponController.Use(player.transform.position);
        // }
        // if(!playerInFieldOfView && !playerInFieldOfAttack) {
        //     if(lastPlayerPosition != null) {
        //         movementController2D.Move(lastPlayerPosition - (Vector2)transform.position);
        //     }
        // }
    }

    // private void OnCollisionStay2D(Collision2D col) {
    //     destination = navigationMap.FindNextPoint(destination, this);
    // }


    void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position + transform.up * fieldOfViewRadius, transform.position + transform.right * fieldOfViewRadius, Color.blue);
        Debug.DrawLine(transform.position + transform.right * fieldOfViewRadius, transform.position - transform.up * fieldOfViewRadius, Color.blue);
        Debug.DrawLine(transform.position - transform.up * fieldOfViewRadius, transform.position - transform.right * fieldOfViewRadius, Color.blue);
        Debug.DrawLine(transform.position - transform.right * fieldOfViewRadius, transform.position + transform.up * fieldOfViewRadius, Color.blue);

        Debug.DrawLine(transform.position + transform.up * fieldOfAttackRadius, transform.position + transform.right * fieldOfAttackRadius, Color.red);
        Debug.DrawLine(transform.position - transform.right * fieldOfAttackRadius, transform.position + transform.right * fieldOfAttackRadius, Color.red);
        Debug.DrawLine(transform.position - transform.right * fieldOfAttackRadius, transform.position + transform.up * fieldOfAttackRadius, Color.red);
    }

    public GameObject Player {
        get {
            return player;
        }
    }

    public float FieldOfViewRadius {
        get {
            return fieldOfViewRadius;
        }
    }

    public float FieldOfAttackRadius {
        get {
            return fieldOfAttackRadius;
        }
    }

    public Vector2 PlayerPosition {
        get {
            return playerPosition;
        }
        set {
            playerPosition = value;
        }
    }

    private MovementController2D movementController2D;
    private CharacterWeaponController characterWeaponController;


}
