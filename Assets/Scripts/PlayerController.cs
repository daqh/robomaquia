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

    void Update()
    {
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);
        bool up = Input.GetKey(KeyCode.W);
        bool down = Input.GetKey(KeyCode.S);
        if (up)
        {
            characterManager.RunController.Run(0);
        }
        if (right)
        {
            characterManager.RunController.Run(90);
            if (!left) characterManager.FlipController.WatchRight();
        }
        if (left)
        {
            characterManager.RunController.Run(270);
            if (!right) characterManager.FlipController.WatchLeft();
        }
        if (down)
        {
            characterManager.RunController.Run(180);
        }
        if (Input.GetMouseButtonDown(0) || (characterManager.ToolController.Loop && Input.GetMouseButton(0)))
        {
            Vector3 screenPosition = Input.mousePosition;
            Vector2 worldPosition =
                Camera.main.ScreenToWorldPoint(screenPosition);
            Vector2 relativePosition =
                worldPosition - (Vector2) transform.position;
            if (!(left ^ right))
            {
                if (relativePosition.x < 0)
                {
                    characterManager.FlipController.WatchLeft();
                }
                if (relativePosition.x > 0)
                {
                    characterManager.FlipController.WatchRight();
                }
            }
            characterManager.ToolController.Use (relativePosition);
        }
    }
}
