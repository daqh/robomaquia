using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    [SerializeField]
    private List<Tool> items;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public List<Tool> Items {
        get {
            return items;
        }
    }

}
