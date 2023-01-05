using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController2D))]
[RequireComponent(typeof(CharacterFactory))]
[RequireComponent(typeof(FlipController))]
public class CharacterAnimationManager : MonoBehaviour
{

    private MovementController2D movementController2D;
    private FlipController flipController;
    private CharacterFactory characterFactory;
    private CharacterWeaponController characterWeaponController;

    private void Awake() {
        movementController2D = GetComponent<MovementController2D>();
        characterWeaponController = GetComponent<CharacterWeaponController>();
        flipController = GetComponent<FlipController>();
    }

    void Start()
    {
        characterFactory = GetComponent<CharacterFactory>();
        movementController2D.OnMove += OnMove;
        characterWeaponController.OnUseWeapon += OnUseWeapon;
    }

    private void OnMove(Vector2 direction) {
        if(direction.x > 0) {
            flipController.WatchRight();
        }
        if(direction.x < 0) {
            flipController.WatchLeft();
        }
        if(direction.magnitude > 0) {
            characterFactory.EffectiveCharacter.GetComponent<Animator>().SetBool("Run", true);
        } else {
            characterFactory.EffectiveCharacter.GetComponent<Animator>().SetBool("Run", false);
        }
    }

    private void OnUseWeapon(Vector2 position) {
        if(position.x < transform.position.x) {
            flipController.WatchLeft();
        }
        if(position.x > transform.position.x) {
            flipController.WatchRight();
        }
    }

    void Destroy() {
        movementController2D.OnMove -= OnMove;
        characterWeaponController.OnUseWeapon -= OnUseWeapon;
    }

}
