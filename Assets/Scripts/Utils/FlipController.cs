using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipController : MonoBehaviour
{

    // private Animator animator;

    private void Awake() {
        // animator = GetComponent<Animator>();
    }

    public void WatchRight() {
        transform.localScale = new Vector2(1, 1);
        // animator.SetBool("Flip", false);
    }

    public void WatchLeft() {
        transform.localScale = new Vector2(-1, 1);
        // animator.SetBool("Flip", true);
    }

}
