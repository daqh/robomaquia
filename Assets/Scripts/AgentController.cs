using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof (CharacterManager))]
public class AgentController : MonoBehaviour
{
    // private CharacterManager characterManager;

    // [SerializeField]
    // private Transform target;

    // [SerializeField]
    // private float nextWaypointDistance = 0.1f;

    // private Path path;

    // private Seeker seeker;

    // private int currentWaypoint = 0;

    // private bool endOfPath = false;

    // void Start()
    // {
    //     seeker = GetComponent<Seeker>();
    //     characterManager = GetComponent<CharacterManager>();
    //     characterManager.SetItem(0);

    //     InvokeRepeating("UpdatePath", 0f, 0.7f);
    // }

    // void UpdatePath()
    // {
    //     if (seeker.IsDone())
    //         seeker
    //             .StartPath(transform.position, target.position, OnPathComplete);
    // }

    // void OnPathComplete(Path path)
    // {
    //     if (!path.error)
    //     {
    //         this.path = path;
    //         currentWaypoint = 0;
    //     }
    // }

    // void Update()
    // {
    //     float distanceFromTarget = Vector2.Distance(transform.position, target.position);
    //     if(distanceFromTarget > 2) {
    //         return;
    //     }
    //     if(distanceFromTarget < 0.5f) {
    //         // characterManager.UseTool(target.position);
    //         return;
    //     };
    //     if (path == null) return;
    //     if (currentWaypoint >= path.vectorPath.Count)
    //     {
    //         endOfPath = true;
    //         nextWaypointDistance = 3f;
    //         return;
    //     }
    //     else
    //     {
    //         endOfPath = false;
    //         nextWaypointDistance = 0.1f;
    //     }
    //     Vector2 direction =
    //         path.vectorPath[currentWaypoint] - transform.position;
    //     characterManager.Move (direction);
    //     float distance =
    //         Vector2
    //             .Distance(transform.position, path.vectorPath[currentWaypoint]);
    //     if (distance < nextWaypointDistance)
    //     {
    //         currentWaypoint++;
    //     }
    // }
}
