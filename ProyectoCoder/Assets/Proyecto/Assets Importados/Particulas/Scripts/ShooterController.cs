using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public GameObject bullet;
    public Transform pointOfShoot;
    public ParticleSystem vfx;

    public void ShootNow()
    {
        Instantiate(bullet, pointOfShoot.position, pointOfShoot.rotation);
        vfx.Play();
    }
}
