using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField]
    private float immunityDuration = 1;

    [SerializeField]
    [Range(0, 100)]
    private int health = 100;

    [SerializeField]
    private AudioClip damageClip;

    private AudioSource audioSource;

    private Animator animator;
    private float timeFromLastDamage = 0;
    private void Start() {
        animator = GetComponent<Animator>();
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource.clip = damageClip;
    }

    private void Update()
    {
        timeFromLastDamage += Time.deltaTime;
        if(Immune) {
            animator.SetBool("Immunity", true);
        } else {
            animator.SetBool("Immunity", false);
        }
    }

    public void Damage(int amount)
    {
        animator.SetTrigger("Hit");
        health -= amount;
        timeFromLastDamage = 0;
        audioSource.Play();
    }

    public bool Immune {
        get {
            return timeFromLastDamage < immunityDuration;
        }
    }


}
