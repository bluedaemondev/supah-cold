using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunpoint : MonoBehaviour
{
    [HideInInspector]
    public Transform gunpointTransform;

    public void Start()
    {
        this.gunpointTransform = transform;
    }
}
