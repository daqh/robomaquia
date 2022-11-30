using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float lifeTime = 10;

    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private int damage = 10;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(transform.up * 100);
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(rigidbody2D.velocity.magnitude == 0 && lifeTime < 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

    }

}
