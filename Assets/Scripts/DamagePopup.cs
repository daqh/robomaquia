using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class DamagePopup : MonoBehaviour
{

    [SerializeField]
    private float lifeTime = 0.7f;

    [SerializeField]
    private float speed = 1;

    private TextMeshPro textMeshPro;

    void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed * (lifeTime + speed);
        if(lifeTime < 0) {
            Debug.Log(textMeshPro.color.a);
            if(textMeshPro.color.a < 0) {
                Destroy(gameObject);
            }
            Color color = textMeshPro.color;
            color.a -= Time.deltaTime;
            textMeshPro.color = color;
        }
        lifeTime -= Time.deltaTime;
    }

    public float Speed {
        get {
            return speed;
        }
        set {
            speed = value;
        }
    }

    public float LifeTime {
        get {
            return lifeTime;
        }
        set {
            lifeTime = value;
        }
    }

}
