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

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 force = direction.normalized * Time.deltaTime * multiplier;
        rigidbody2D.AddForce (force);
        OnMove?.Invoke(direction);
    }

    private void Update() {
        direction = Vector2.zero;
    }

    public void Move(Vector2 direction)
    {
        this.direction += direction;
    }

    public Vector2 Direction
    {
        get
        {
            return direction;
        }
    }

    public float Multiplier {
        get {
            return multiplier;
        }
        set {
            multiplier = value;
        }
    }

    public Action<Vector2> OnMove;

    private Rigidbody2D rigidbody2D;

    private Animator animator;

    private Vector2 direction = Vector2.zero;
}
