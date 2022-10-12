using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] bool MovingOut;


    [SerializeField] float Speed;
    [SerializeField] float Damage;

    public float Speed1 { get => Speed; set => Speed = value; }
    public float Damage1 { get => Damage; set => Damage = value; }
    public bool MovingOut1 { get => MovingOut; set => MovingOut = value; }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (MovingOut1) { movv(); }   
    }

    void movv()
    {
        transform.Translate(0, 0, -Speed1 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.transform.gameObject.GetComponent<EnemyHP>().RestarVida(Damage1, new Vector3(0, 0, 0));
        }

        if (other.CompareTag("Boss"))
        {
            other.transform.gameObject.GetComponent<HP_BOSS>().RestarVida(Damage1);
        }
    }
}
