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
    }

    private void Update() {
        animator.SetFloat("Speed", speed);
        if(!InUse) {
            gameObject.SetActive(false);
        }
    }

    private bool usedThisFrame = false;

    public void LateUpdate() {
        usedThisFrame = false;
    }

    public void Use(Vector2 position) {
        if(!InUse) {
        usedThisFrame = true;
            audioSource.Play();
            animator.SetTrigger("Use");
            OnUse(position);
        }
    }

    public virtual void OnUse(Vector2 position) {

    }

    public bool InUse {
        get {
            return animator.GetCurrentAnimatorStateInfo(0).IsName("Use Tool") || (usedThisFrame && lockFlipOnUse);
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
