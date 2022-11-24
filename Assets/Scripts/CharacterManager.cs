using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (HealthController))]
[RequireComponent(typeof (MovementController2D))]
[RequireComponent(typeof (ToolController))]
public class CharacterManager : MonoBehaviour
{
    private MovementController2D movementController2D;

    private HealthController healthController;

    private ToolController toolController;

    private FlipController flipController;

    void Awake()
    {
        flipController =
            gameObject.AddComponent(typeof (FlipController)) as FlipController;
        movementController2D = GetComponent<MovementController2D>();
        healthController = GetComponent<HealthController>();
        toolController = GetComponent<ToolController>();
    }

    public void Move(Vector2 direction)
    {
        if(toolController.Tool != null) {
            if (!toolController.Tool.InUse || !toolController.Tool.LockFlipOnUse)
            {
                if (direction.x < 0)
                {
                    flipController.WatchLeft();
                }
                else if (direction.x > 0)
                {
                    flipController.WatchRight();
                }
            }
        }
        movementController2D.Move (direction);
    }

    public void UseTool(Vector2 position)
    {
        if(toolController.Tool.FlipCharacter && (!toolController.Tool.LockFlipOnUse || !toolController.Tool.gameObject.active)) {
            Vector2 relativePosition = position - (Vector2)transform.position;
            if(relativePosition.x < 0) flipController.WatchLeft();
            else if(relativePosition.x > 0) flipController.WatchRight();
        }
        toolController.Use (position);
    }
}
