using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SmoothFollowingCamera2D : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed = 1;

    void LateUpdate()
    {
        if(target != null) {
            float distance =
                Vector3
                    .Distance(new Vector3(transform.position.x,
                        transform.position.y,
                        0),
                    target.position);
            Vector3 difference =
                new Vector3(target.position.x, target.position.y, 0) -
                new Vector3(transform.position.x, transform.position.y, 0);
            transform.position += difference * Time.deltaTime * speed;
        }
    }

    void OnDrawGizmos()
    {
        if(transform) {
            float distance =
                Vector3
                    .Distance(new Vector3(transform.position.x,
                        transform.position.y,
                        0),
                    target.position);
            Vector3 middle = (transform.position + target.position) / 2;
            Debug.DrawLine(transform.position, target.position);
            Handles.Label(middle, distance.ToString());
        }
    }

    private void OnDestroy() {
        
    }

}
