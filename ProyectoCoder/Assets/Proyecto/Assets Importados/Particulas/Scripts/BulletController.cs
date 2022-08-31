using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speedBullet;
    public AudioSource audioSource;
    public AudioClip clip;
    public GameObject impactVFX;
    public GameObject bloodVFX;
    void Start()
    {
        audioSource.pitch = (Random.Range(0.9f, 1f));
        audioSource.volume = 0.1f;
        audioSource.PlayOneShot(clip);

    }
    void Update()
    {
        transform.position += transform.forward * speedBullet * Time.deltaTime;
        Destroy(gameObject, 3f);

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Default"))
        {
            Instantiate(impactVFX, transform.position, transform.rotation);;
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(bloodVFX, transform.position, transform.rotation);

        }
    }
}
