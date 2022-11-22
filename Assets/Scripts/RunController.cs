using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunController : MonoBehaviour
{
    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rigidbody2D;

    private FlipController flipController;

    [SerializeField]
    private float speed = 20;

    [SerializeField]
    private float maxSpeed = 1.7f;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private List<float> degrees = new List<float>();
    private Vector2 direction;
    private List<Vector2> directions = new List<Vector2>();

    private bool isRunning = false;

    void Update()
    {
        Vector2 destination = Vector2.zero;
        foreach(Vector2 direction in directions) {
            destination += direction;
        }
        destination.Normalize();
        Debug.DrawLine(transform.position, (Vector2)transform.position + destination);
        if (destination != Vector2.zero)
        {
            if (isRunning == false)
            {
                animator.SetBool("isRunning", isRunning = true);
            }
        }
        else
        {
            if (isRunning == true)
            {
                animator.SetBool("isRunning", isRunning = false);
            }
        }
        if (rigidbody2D.velocity.magnitude <= maxSpeed)
        {
            rigidbody2D.AddForce(destination * Time.deltaTime * speed);
        }
        directions.Clear();
    }


    public void Run(float degree)
    {
        Vector2 direction =
            new Vector2(1 * Mathf.Sin((Mathf.PI / 180) * degree),
                1 * Mathf.Cos((Mathf.PI / 180) * degree));
        directions.Add(direction);
    }

    public void Run(Vector2 direction) {
        direction.Normalize();
        directions.Add(direction);
    }

}
