using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController2D))]
[RequireComponent(typeof(CharacterWeaponController))]
public class PlayerController2D : MonoBehaviour
{

    void Awake()
    {
        movementController2D = GetComponent<MovementController2D>();
        characterWeaponController = GetComponent<CharacterWeaponController>();
    }

    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.D)) {
            movementController2D.Move(transform.right);
        }
        if(Input.GetKey(KeyCode.A)) {
            movementController2D.Move(-transform.right);
        }
        if(Input.GetKey(KeyCode.W)) {
            movementController2D.Move(transform.up);
        }
        if(Input.GetKey(KeyCode.S)) {
            movementController2D.Move(-transform.up);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 worldPosition =
                Camera.main.ScreenToWorldPoint(mousePosition);
            characterWeaponController.Use(worldPosition);
        }
    }

    private MovementController2D movementController2D;
    private CharacterWeaponController characterWeaponController;

}
