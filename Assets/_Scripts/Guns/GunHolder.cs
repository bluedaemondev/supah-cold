using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    public bool hasEquipedGun = true;
    public GameObject prefabHold;


    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            OnShoot();
        }
    }

    public void OnShoot()
    {
        var gunRef = prefabHold.GetComponent<Gun>();
        gunRef.Shoot();

    }
}
