using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float hMove, vMove;
    ShooterController shooterC;


    [Header("Skills")]
    public float speed;
    public float rotateSpeed;
    bool isAiming;
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        shooterC = FindObjectOfType<ShooterController>();
    }
    void Update()
    {
        Movement();
        Aiming();
        AnimatorController();


    }
    void Movement()
    {
        if (isAiming == true)
        {
            vMove = 0;
            Shooting();
        }
        else
        {
            vMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        }

        hMove = Input.GetAxis("Horizontal") * speed * rotateSpeed * Time.deltaTime;

        transform.Rotate(0, hMove, 0);
        transform.Translate(0, 0, vMove);
    }
    void Aiming()
    {
        if (Input.GetKey(KeyCode.J))
        {
            isAiming = true;
        }
        else isAiming = false;

    }
    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            shooterC.ShootNow();
        }
    }
    void AnimatorController()
    {
        anim.SetBool("IsAiming", isAiming);

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TriggerCam"))
        {
            
        }
    }



}
