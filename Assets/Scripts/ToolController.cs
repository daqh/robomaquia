using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    private Tool tool;

    [SerializeField]
    private Vector2 offset;

    // private Tool _tool;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource =
            gameObject.AddComponent(typeof (AudioSource)) as AudioSource;
    }

    public void Use(Vector2 position)
    {
        if(tool) {
            tool.gameObject.SetActive(true);
            tool.Use (position);
        }
    }

    public Tool Tool
    {
        get
        {
            return tool;
        }
        set
        {
            if(HasTool && tool.InUse) return;
            Tool _ = tool;
            if(value != null) {
                tool =
                    Instantiate(value,
                    (Vector2) transform.position + offset * new Vector2(transform.localScale.x/Mathf.Abs(transform.localScale.x), transform.localScale.y/Mathf.Abs(transform.localScale.y)),
                    Quaternion.identity,
                    transform
                );
                tool.gameObject.SetActive(false);
            }
            if(_ != null) Destroy(_.gameObject);
        }
    }

    public Vector2 Offset
    {
        get
        {
            return offset;
        }
    }

    public bool HasTool {
        get {
            return tool != null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere((Vector2) transform.position + offset, .01f);
    }
}
