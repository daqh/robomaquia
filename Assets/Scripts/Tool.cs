using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public abstract class Tool : MonoBehaviour
{

    [SerializeField]
    private bool lockFlipOnUse;

    [SerializeField]
    private bool flipCharacter;

    [SerializeField]
    private bool loop;

    [SerializeField]
    private AudioClip useClip;

    [SerializeField]
    [Range(0.1f, 10)]
    private float speed;

    private AudioSource audioSource;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource.clip = useClip;
        animator.SetFloat("Speed", speed);
    }

    private void Update() {
        if(!InUse) {
            animator.SetFloat("Speed", speed);
            Debug.Log(animator.GetFloat("Speed"));
            gameObject.SetActive(false);
        }
    }

    public void Use(Vector2 position) {
        if(!InUse) {
            audioSource.Play();
            animator.SetTrigger("Use");
        }
    }

    public bool InUse {
        get {
            return animator.GetCurrentAnimatorStateInfo(0).IsName("Use Tool");
        }
    }

    public bool FlipCharacter {
        get {
            return flipCharacter;
        }
    }

    public bool LockFlipOnUse {
        get {
            return lockFlipOnUse;
        }
    }

}
