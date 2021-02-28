using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sigue el mouse constantemente, usado para el player
/// </summary>
/// 

public class HandGunAim : MonoBehaviour
{
    void Update()
    {
        FollowMousePosition();
        if (Input.GetMouseButton(0))
        {
            GetComponent<GunHolder>().OnShoot();
        }
    }
    void FollowMousePosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        var aimDirection = (mousePos - transform.position ).normalized;
        float angleRotation = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angleRotation);
    }

    
}
