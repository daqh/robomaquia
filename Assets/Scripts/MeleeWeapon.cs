using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Tool
{

    [SerializeField]
    [Range(0, 100)]
    private int damage;

    [SerializeField]
    [Range(0, 100)]
    private float shove = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject o = other.gameObject;
        if(InUse) {
            HealthController healthController = o.GetComponent<HealthController>();
            if(healthController) {
                if(!healthController.Immune) {
                    healthController.Damage(damage + (int)Mathf.Round(Random.Range(0, Mathf.Log(damage, 2)))); // TODO: Migliorare la generazione casuale del danno
                    Rigidbody2D rigidbody2D = o.GetComponent<Rigidbody2D>();
                    Vector2 bump = o.transform.position - transform.position;
                    bump.Normalize();
                    rigidbody2D.AddForce(bump * Mathf.Log(damage, 2) * shove);
                }
            }
        }
    }

}
