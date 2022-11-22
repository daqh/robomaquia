using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip damageClip;

    [SerializeField]
    private Transform textPopup;

    [SerializeField]
    private Color damageColor = Color.red;

    [SerializeField]
    private float immunityDuration = 1;
    
    private float immunityCountdown = 0;

    private float randomFactor = 0.5f;

    private float timeFromLastDamage = 0;

    [SerializeField]
    [Range(0, 100)]
    private int health = 100;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
    }

    void Update() {
        timeFromLastDamage += Time.deltaTime;
        if(Immune) {
            immunityCountdown -= Time.deltaTime;
            animator.SetBool("Immunity", true);
        } else {
            animator.SetBool("Immunity", false);
        }
    }

    private void LateUpdate() {
        if(health <= 0) {
            Destroy(gameObject);
        }    
    }

    public void Damage(int amount)
    {
        if(!Immune) {
            int realAmount = amount + (int)Mathf.Floor(Random.Range(0, amount/2f));
            audioSource.clip = damageClip;
            audioSource.Play();
            animator.SetTrigger("Hit");
            Transform textPopupTransform = Instantiate(textPopup, transform.position, Quaternion.identity);
            TextPopup _ = textPopupTransform.GetComponent<TextPopup>();
            _.SetText(realAmount.ToString());
            _.SetFontSize(1 + Mathf.Pow(realAmount/100f, 2));
            _.SetColor(Color.Lerp(Color.white, damageColor, (realAmount - amount)/(amount/2f)));
            immunityCountdown = immunityDuration;
            health -= realAmount;
            timeFromLastDamage = 0;
        }
    }

    public bool Immune {
        get {
            return immunityCountdown > 0;
        }
    }
}
