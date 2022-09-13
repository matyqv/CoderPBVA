using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicZombie1 : MonoBehaviour
{

    PlayerController player;
    public float distanceToFollow;
    NavMeshAgent navMesh;
    Animator anim;
    AudioSource audioSource;

    bool isDead;
    public Rigidbody handR, handL, body;
    public int life;
    public GameObject deadEyes, Eyebrow;
    public AudioClip[] damageSFX;
    public AudioClip deadSFX;


    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(1.6f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= distanceToFollow)
            {
                navMesh.SetDestination(player.transform.position);
                transform.LookAt(player.transform.position);
                anim.SetBool("IsMoving", true);


            }
            else anim.SetBool("IsMoving", false);
        }


        if (life <= 0)
        {
            isDead = true;
            navMesh.enabled = false;
            anim.enabled = false;
            handL.isKinematic = false;
            handR.isKinematic = false;
            body.isKinematic = false;
            Eyebrow.SetActive(false);
            deadEyes.SetActive(true);
            DeathCondition();

        }
    }
    void DeathCondition()
    {
        audioSource.PlayOneShot(deadSFX);
        life=1;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            audioSource.PlayOneShot(damageSFX[Random.Range(0, damageSFX.Length)]);
            life--;
        }

    }
}
