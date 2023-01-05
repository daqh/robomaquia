using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{

    [SerializeField]
    private Vector2 offset;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere((Vector2) transform.position + offset * transform.localScale, .01f);
    }

    public Vector2 Offset {
        get {
            return offset;
        }
    }

}
