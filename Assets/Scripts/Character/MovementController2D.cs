using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class MovementController2D : MonoBehaviour
{

    [SerializeField]
    [Range(0, 100)]
    private float multiplier = 10;

    private Rigidbody2D rigidbody2D;

    private Animator animator;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private Vector2 direction = Vector2.zero;

    public void FixedUpdate()
    {
        // direction.Normalize();
        rigidbody2D.AddForce (direction.normalized * Time.deltaTime * multiplier);
        if(direction != Vector2.zero) {
            animator.SetBool("Run", true);
        } else {
            animator.SetBool("Run", false);
        }
        direction = Vector2.zero;
    }

    public void Move(Vector2 direction)
    {
        this.direction += direction;
    }

    public Vector2 Direction {
        get {
            return direction;
        }
    }

}
