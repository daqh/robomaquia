using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipController : MonoBehaviour
{

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    public void WatchRight() {
        animator.SetBool("Flip", false);
    }

    public void WatchLeft() {
        animator.SetBool("Flip", true);
    }

}
