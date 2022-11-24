using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    [SerializeField]
    private Tool tool;

    [SerializeField]
    private Vector2 offset;

    private Tool _tool;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource =
            gameObject.AddComponent(typeof (AudioSource)) as AudioSource;
        if (tool != null)
        {
            audioSource.clip = 
            _tool =
                Instantiate(tool,
                (Vector2) transform.position + offset,
                Quaternion.identity);
            _tool.transform.parent = transform;
            _tool.gameObject.SetActive(false);
        }
    }

    public void Use(Vector2 position)
    {
        _tool.gameObject.SetActive(true);
        _tool.Use (position);
    }

    public Tool Tool
    {
        get
        {
            return _tool;
        }
    }

    public Vector2 Offset
    {
        get
        {
            return offset;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere((Vector2) transform.position + offset, .01f);
    }
}
