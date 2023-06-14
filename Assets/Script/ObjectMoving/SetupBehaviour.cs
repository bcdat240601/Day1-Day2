using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        // override
    }
    protected virtual void Awake()
    {
        LoadComponents();
    }
}
