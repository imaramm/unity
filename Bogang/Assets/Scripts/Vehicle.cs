using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle
{
    protected bool isReady = false;

    public virtual void EngineStart()
    {
        isReady = true;
        Debug.Log("Engine Start");
    }

    public abstract void Driving();
}
