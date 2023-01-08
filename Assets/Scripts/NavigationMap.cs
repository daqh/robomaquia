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
        List<NavigationPoint> neighbours = GetNeighbours(point);
        NavigationPoint bestNavigationPoint = neighbours[UnityEngine.Random.Range(0, neighbours.Count)];
        GameObject[] agents = GameObject.FindGameObjectsWithTag("Agent");
        foreach(NavigationPoint np in neighbours) {
            if(np == point) continue;
            float pathCost = GetPathCost(point, np);
            float minDistanceFromAgent = np.MinDistanceFromAgent(agent);
            float priorityFactor = (minDistanceFromAgent * agents.Length) / pathCost;
            if(priorityFactor > (bestNavigationPoint.MinDistanceFromAgent(agent) * agents.Length) / GetPathCost(point, bestNavigationPoint)) {
                bestNavigationPoint = np;
            }
        }
        return bestNavigationPoint;
    }

    public float GetPathCost(NavigationPoint a, NavigationPoint b) {
        return Vector2.Distance(a.transform.position, b.transform.position);
        // Queue<NavigationPoint> queue = new Queue<NavigationPoint>();
        // List<NavigationPoint> explored = new List<NavigationPoint>();
        // queue.Enqueue(a);
        // explored.Add(a);
        // while(queue.Count > 0) {
        //     NavigationPoint np = queue.Dequeue();
        //     // Se np == b, ho finito
        //     foreach(NavigationPoint neighbour in GetNeighbours(np)) {
        //         if(!explored.Contains(neighbour)) {
        //             explored.Add(neighbour);
        //             queue.Enqueue(neighbour);
        //         }
        //     }
        // }
    }

    public List<NavigationPoint> GetNeighbours(NavigationPoint navigationPoint) {
        List<NavigationPoint> navigationPoints = new List<NavigationPoint>();
        foreach(Edge edge in edges) {
            if(edge.A == navigationPoint) {
                navigationPoints.Add(edge.B);
            } else if(edge.B == navigationPoint) {
                navigationPoints.Add(edge.A);
            }
        }
        return navigationPoints;
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
