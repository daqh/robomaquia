using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (HealthController))]
[RequireComponent(typeof (MovementController2D))]
[RequireComponent(typeof (WeaponController))]
[RequireComponent(typeof (InventoryController))]
public class CharacterController : MonoBehaviour
{
    private MovementController2D movementController2D;

    private HealthController healthController;

    private WeaponController toolController;

    private FlipController flipController;

    private InventoryController inventoryController;

    void Awake()
    {
        flipController =
            gameObject.AddComponent(typeof (FlipController)) as FlipController;
        movementController2D = GetComponent<MovementController2D>();
        healthController = GetComponent<HealthController>();
        toolController = GetComponent<WeaponController>();
        inventoryController = GetComponent<InventoryController>();
    }

    void Start()
    {
        SetItem(0);
    }

    public void Move(Vector2 direction)
    {
        if (toolController.Tool != null)
        {
            if (!toolController.Tool.InUse || !toolController.Tool.LockFlipOnUse
            )
            {
                if (direction.x < 0)
                {
                    flipController.WatchLeft();
                }
                if (direction.x > 0)
                {
                    flipController.WatchRight();
                }
            }
        }
        else
        {
            if (direction.x < 0)
            {
                flipController.WatchLeft();
            }
            if (direction.x > 0)
            {
                flipController.WatchRight();
            }
        }
        movementController2D.Move (direction);
    }

    public void UseTool(Vector2 position)
    {
        if (toolController.Tool != null)
        {
            if (toolController.Tool.FlipCharacter && !toolController.Tool.InUse)
            {
                Vector2 relativePosition =
                    position - (Vector2) transform.position;
                if (relativePosition.x < 0)
                    flipController.WatchLeft();
                else if (relativePosition.x > 0) flipController.WatchRight();
            }
            toolController.Use (position);
        }
    }

    public void SetItem(int index)
    {
        // if(index < inventoryController.Items.Count - 1) {
        Debug.Log(inventoryController.Items[index]);
        toolController.Tool = inventoryController.Items[index];
        // }
    }
}
