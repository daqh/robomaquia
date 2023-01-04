using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    [SerializeField]
    private KeyCode leftKey = KeyCode.A;

    [SerializeField]
    private KeyCode rightKey = KeyCode.D;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            characterController.SetItem(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            characterController.SetItem(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            characterController.SetItem(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            characterController.SetItem(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)) {
            characterController.SetItem(4);
        }
        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move(transform.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(-transform.up);
        }
        if (Input.GetKey(leftKey))
        {
            characterController.Move(-transform.right);
        }
        if (Input.GetKey(rightKey))
        {
            characterController.Move(transform.right);
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 worldPosition =
                Camera.main.ScreenToWorldPoint(mousePosition);
            characterController.UseTool(worldPosition);
        }
    }

}
