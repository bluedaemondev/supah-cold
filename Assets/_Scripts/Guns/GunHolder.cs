using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    public bool hasEquipedGun = true;
    public GameObject prefabHold;

    public void OnShoot()
    {
        var gunRef = prefabHold.GetComponent<Gun>();
        gunRef.Shoot();

    }
}
