using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipController : MonoBehaviour
{

    private Vector2 localScale;
    private bool isFlipped = false;

    void Start() {
        localScale = transform.localScale;
    }

    public void WatchLeft() {
        if(!isFlipped) {
            transform.localScale = new Vector2(-localScale.x, localScale.y);
            isFlipped = true;
        }
    }

    public void WatchRight() {
        transform.localScale = localScale;
        isFlipped = false;
    }

}
