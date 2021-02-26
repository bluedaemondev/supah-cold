using System.Collections;
using UnityEngine;

public interface IGun 
{
    void Shoot();
    IEnumerator Cooldown(float timeCd);
    void ThrowSelf(Vector3 direction);
    void Aim(Vector3 targetPosition);
    void PickUp();

}
