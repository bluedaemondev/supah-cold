using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandgunAim : HandGunAim
{
    public override void Update()
    {
        base.Update();

        if (Input.GetMouseButton(0))
        {
            GetComponent<GunHolder>().OnShoot();
            FindObjectOfType<CameraShake>().ShakeCameraNormal(1f, 0.1f);

        }
    }
    public override void TargetAim()
    {
        base.TargetAim();
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        var aimDirection = (mousePos - transform.position).normalized;
        float angleRotation = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angleRotation);
    }
}
