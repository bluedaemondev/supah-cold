using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sigue el mouse constantemente, usado para el player
/// </summary>
/// 

public class HandGunAim : MonoBehaviour
{
    public virtual void Update()
    {
        TargetAim();
        
    }
    public virtual void TargetAim()
    {
        //Debug.Log("Aiming");
    }

    
}
