using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPoint : MonoBehaviour
{


    public float MinDistanceFromAgent(AgentController agent) {
        GameObject[] agents = GameObject.FindGameObjectsWithTag("Agent");
        float minDistance = float.MaxValue;
        foreach(GameObject a in agents) {
            if(a == agent) continue;
            float distance = Vector2.Distance(transform.position, a.transform.position);
            if(distance < minDistance) {
                minDistance = distance;
            }
        }
        return minDistance;
    }

}
