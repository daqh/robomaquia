using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Tool
{

    private Animator animator;

    private int damage = 10;

    public override bool OnUse(Vector2 position)
    {
        if (!AreUsing)
        {
            animator.SetTrigger("use");
        }
        return !AreUsing;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void LateUpdate() {
        if(!AreUsing) {
            gameObject.SetActive(false);
        }    
    }

    public override bool AreUsing
    {
        get
        {
            return animator == null ? false : animator.GetCurrentAnimatorStateInfo(0).IsName("use");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject o = other.gameObject;
        if(AreUsing) {
            HealthController healthController = o.GetComponent<HealthController>();
            if(healthController) {
                if(!healthController.Immune) {
                    healthController.Damage(damage);
                    Rigidbody2D rigidbody2D = o.GetComponent<Rigidbody2D>();
                    Debug.Log(rigidbody2D);
                    if(rigidbody2D) {
                        Vector2 bump = o.transform.position - transform.position;
                        bump.Normalize();
                        rigidbody2D.AddForce(bump * Mathf.Log(damage, 2));
                    }
                }
            }
        }
    }

}
