using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NavigationMap : MonoBehaviour
{

    [Serializable]
    public class Edge {

        [SerializeField]
        private NavigationPoint a;

        [SerializeField]
        private NavigationPoint b;
    
        public NavigationPoint A {
            get {
                return a;
            }
        }

        public NavigationPoint B {
            get {
                return b;
            }
        }
    }

    [SerializeField]
    private List<Edge> edges = new List<Edge>();

    private List<NavigationPoint> navigationPoints = new List<NavigationPoint>();

    private void Awake() {
        GameObject[] _ = GameObject.FindGameObjectsWithTag("Navigation Point");
        foreach(GameObject go in _) {
            navigationPoints.Add(go.GetComponent<NavigationPoint>());
        }
    }

    public NavigationPoint FindNextPoint(NavigationPoint point, AgentController agent) {
        foreach(Edge edge in edges) {
            
        }
    }

    public NavigationPoint FindClosestPoint(Vector2 position) {
        NavigationPoint closestPoint = navigationPoints[0];
        foreach(NavigationPoint np in navigationPoints) {
            if(Vector2.Distance(position, np.transform.position) < Vector2.Distance(position, closestPoint.transform.position)) {
                closestPoint = np;
            }
        }
        return closestPoint;
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos() {
        foreach(Edge edge in edges) {
            Debug.DrawLine(edge.A.transform.position, edge.B.transform.position);
        }
    }

}
