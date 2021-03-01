using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    public int projectilesMin = 5;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void Shoot()
    {
        //base.Shoot();
        if (canShoot)
        {
            for (int i = 0; i < projectilesMin; i++)
            {
                var bullet = Instantiate(prefabShoot, gunpoint.gunpointTransform.position, transform.rotation);
                var bulletDirection = (gunpoint.transform.position - transform.position) * 100 ;
                
                switch (i) {
                    case 0:
                        bulletDirection += new Vector3(0, -2f, 0);
                        break;
                    case 1:
                        bulletDirection += new Vector3(0, -6f, 0);
                        break;
                    case 2:
                        bulletDirection += new Vector3(0, 0f, 0);
                        break;
                    case 3:
                        bulletDirection += new Vector3(0, 6f, 0);
                        break;
                    case 4:
                        bulletDirection += new Vector3(0, 2f, 0);
                        break;
                }

                bullet.GetComponent<Bullet>().LoadAttributesAndShoot( bulletDirection * bulletSpeed);
                Debug.Log("Shooting " + transform.parent.parent.name);
            }

            StartCooldown(cooldownFireRate);

        }
    }
}
