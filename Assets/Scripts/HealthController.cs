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
    private int maxHealth = 100;

    [SerializeField]
    [Range(0, 100)]
    private int health = 100;

    [SerializeField]
    private AudioClip damageClip;

    private AudioSource audioSource;

    private Animator animator;

    [SerializeField]
    private Rigidbody2D rigidbody2D;

    private float timeFromLastDamage = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource =
            gameObject.AddComponent(typeof (AudioSource)) as AudioSource;
        audioSource.clip = damageClip;
    }

    private void Update()
    {
        timeFromLastDamage += Time.deltaTime;
        if (Immune)
        {
            animator.SetBool("Immunity", true);
        }
        else
        {
            animator.SetBool("Immunity", false);
        }
    }

    public void Damage(Damage damage)
    {
        animator.SetTrigger("Hit");
        health -= damage.Amount;
        timeFromLastDamage = 0;
        audioSource.Play();
        OnGetDamage?.Invoke(damage);
        OnHealthChange?.Invoke(health);
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnDeath?.Invoke();
        Destroy (rigidbody2D.gameObject);
    }

    public bool Immune
    {
        get
        {
            return timeFromLastDamage < immunityDuration;
        }
    }

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    public int Health
    {
        get
        {
            return health;
        }
    }

    public Rigidbody2D Rigidbody2D {
        get {
            return rigidbody2D;
        }
        set {
            rigidbody2D = value;
        }
    }

    public delegate void OnGetDamageDelegate(Damage amount);

    public event OnGetDamageDelegate OnGetDamage;

    public delegate void OnHealthChangeDelegate(int health);

    public event OnHealthChangeDelegate OnHealthChange;

    public delegate void OnDeathDelegate();

    public event OnDeathDelegate OnDeath;

}
