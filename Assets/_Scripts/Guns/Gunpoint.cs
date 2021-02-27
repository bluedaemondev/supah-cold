using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunpoint : MonoBehaviour
{
    public Transform gunpointTransform;

    private void Start()
    {
        this.gunpointTransform = transform;
    }
}
