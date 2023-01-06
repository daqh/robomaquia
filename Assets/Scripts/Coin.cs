using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{

    private GameObject player;

    [SerializeField]
    private string playerTag = "Player";

    [SerializeField]
    private float deelay = 3;

    [SerializeField]
    private AudioClip onLootClip;

    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);        
        player = players[0];
    }

    private void Update() {
        if(player != null) {
            deelay -= Time.deltaTime;
            if(deelay <= 0) {
                Vector2 direction = player.transform.position - transform.position;
                float multiplier = Mathf.Pow(-deelay, 8) * Time.deltaTime;
                // rigidbody2D.AddForce(direction * multiplier);
                transform.position += (Vector3)direction * multiplier;
            }
        }
    }

    public Rigidbody2D Rigidbody2D {
        get {
            return rigidbody2D;
        }
    }

    public AudioClip OnLootClip {
        get {
            return onLootClip;
        }
    }

    public float Deelay {
        get {
            return deelay;
        }
    }

}