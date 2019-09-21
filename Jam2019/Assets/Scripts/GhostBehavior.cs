using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GhostBehavior : ScriptableObject
{
    public enum BlendType { Additive, Override }

    public BlendType blendType;
    public float additiveWeight = 1;

    public abstract  Vector3 GetDesiredDestination(Transform transform);
    
    private bool IsAdditive() {
        return blendType == BlendType.Additive;
    }


}
