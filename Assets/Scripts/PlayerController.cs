using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterManager))]
public class PlayerController : MonoBehaviour
{

    private CharacterManager characterManager;

    void Start()
    {
        characterManager = GetComponent<CharacterManager>();
    }

    [SerializeField]
    private KeyCode leftKey = KeyCode.A;

    [SerializeField]
    private KeyCode rightKey = KeyCode.D;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            characterManager.SetItem(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            characterManager.SetItem(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            characterManager.SetItem(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            characterManager.SetItem(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)) {
            characterManager.SetItem(4);
        }
        if (Input.GetKey(KeyCode.W))
        {
            characterManager.Move(transform.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            characterManager.Move(-transform.up);
        }
        if (Input.GetKey(leftKey))
        {
            characterManager.Move(-transform.right);
        }
        if (Input.GetKey(rightKey))
        {
            characterManager.Move(transform.right);
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 worldPosition =
                Camera.main.ScreenToWorldPoint(mousePosition);
            characterManager.UseTool(worldPosition);
        }
    }

}
