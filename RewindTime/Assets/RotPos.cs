using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RotPos
{
    public Vector3 position;
    public Quaternion rotation;

    public RotPos(Vector3 p, Quaternion r)
    {
        position = p;
        rotation = r;
    }
}
