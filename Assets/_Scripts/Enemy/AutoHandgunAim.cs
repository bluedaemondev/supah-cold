using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHandgunAim : HandGunAim
{
    public override void Update()
    {
        base.Update();
    }

    public override void TargetAim()
    {
        base.TargetAim();
        var aimDirection = (FindObjectOfType<IDJ_code.CharacterController2D>().transform.position - transform.position).normalized;
        float angleRotation = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angleRotation);
    }
}
