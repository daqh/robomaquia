using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Looter : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Lootable") {
            Coin coin = other.GetComponent<Coin>();
            if(coin.Deelay < 0) {
                AudioSource.PlayClipAtPoint(coin.OnLootClip, transform.position);
                Destroy(other.gameObject);
            }
        }
    }

}