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

    private WeaponController weaponController;

    private FlipController flipController;

    private InventoryController inventoryController;

    void Awake()
    {
        flipController =
            gameObject.AddComponent(typeof (FlipController)) as FlipController;
        movementController2D = GetComponent<MovementController2D>();
        healthController = GetComponent<HealthController>();
        weaponController = GetComponent<WeaponController>();
        inventoryController = GetComponent<InventoryController>();
    }

    void Start()
    {
        SetItem(0);
    }

    public void Move(Vector2 direction)
    {
        if (weaponController.Tool != null)
        {
            if (!weaponController.Tool.InUse || !weaponController.Tool.LockFlipOnUse
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
        if (weaponController.Tool != null)
        {
            if (weaponController.Tool.FlipCharacter && !weaponController.Tool.InUse)
            {
                Vector2 relativePosition =
                    position - (Vector2) transform.position;
                if (relativePosition.x < 0)
                    flipController.WatchLeft();
                else if (relativePosition.x > 0) flipController.WatchRight();
            }
            weaponController.Use (position);
        }
    }

    public void SetItem(int index)
    {
        // if(index < inventoryController.Items.Count - 1) {
        weaponController.Tool = inventoryController.Items[index];
        // }
    }
}
