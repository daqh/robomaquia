using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Collider2D))]
public class Looter : MonoBehaviour
{

    [SerializeField]
    private TMP_Text coinAmountText;

    private int collectedCoins = 0;

    private void Update() {
        // coinAmountText.SetText(collectedCoins.ToString());
        coinAmountText.text = collectedCoins.ToString();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Lootable") {
            Coin coin = other.GetComponent<Coin>();
            if(coin.Deelay < 0) {
                AudioSource.PlayClipAtPoint(coin.OnLootClip, transform.position);
                collectedCoins++;
                Destroy(other.gameObject);
            }
        }
    }

}