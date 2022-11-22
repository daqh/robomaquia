using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ToolController))]
[RequireComponent(typeof(RunController))]
public class CharacterManager : MonoBehaviour
{

    private FlipController flipController;

    private ToolController toolController;

    private RunController runController;

    private void Awake() {
        flipController = gameObject.AddComponent(typeof(FlipController)) as FlipController;
        runController = GetComponent<RunController>();
        toolController = GetComponent<ToolController>();
    }

    public FlipController FlipController {
        get {
            return flipController;
        }
    }

    public RunController RunController {
        get {
            return runController;
        }
    }

    public ToolController ToolController {
        get {
            return toolController;
        }
    }

}
