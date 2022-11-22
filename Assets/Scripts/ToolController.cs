using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ToolController : MonoBehaviour
{

    [SerializeField]
    private Tool tool;

    private Tool child;

    [SerializeField]
    private Vector2 offset = Vector2.zero;

    private AudioSource audioSource;

    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        child = Instantiate(tool, (Vector2)transform.position + offset, Quaternion.identity);
        child.transform.parent = transform;
        child.Owner = this;
        child.gameObject.SetActive(false);
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource.clip = tool.AudioClip;
    }

    void Update()
    {
        
    }

    public bool Loop {
        get {
            return tool.Loop;
        }
    }

    public void Use(Vector2 position) {
        child.gameObject.SetActive(true);
        if(child.Use(position)) {
            audioSource.Play();
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere((Vector2)transform.position + offset, .01f);
    }

    public Rigidbody2D Rigidbody2D {
        get {
            return rigidbody2D;
        }
    } 

}
