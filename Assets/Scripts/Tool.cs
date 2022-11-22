using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool: MonoBehaviour
{

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private bool loop = true;

    public bool Use(Vector2 position) {
        return OnUse(position);
    }

    public abstract bool OnUse(Vector2 position);

    public bool Loop {
        get {
            return loop;
        }
    }

    public abstract bool AreUsing {
        get;
    }

    public AudioClip AudioClip {
        get {
            return audioClip;
        }
    }

    private ToolController owner;

    public ToolController Owner {
        get {
            return owner;
        }
        set {
            owner = value;
        }
    }

}
