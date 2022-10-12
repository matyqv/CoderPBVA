using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AtaqueMeleEnemy : MonoBehaviour
{
    public GameObject Target;
    [SerializeField] float Damage;
    [SerializeField] float Detectado;


    public UnityEvent ATKMele;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Target = other.transform.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Detectado += 10 * Time.deltaTime;
            if (Detectado > 8)
            {
                ATKMele?.Invoke();
                Detectado = 0;
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Detectado = 5;
            Target = null;
        }
    }

    public void Ataque()
    {
        PlayerHp PHP = Target.GetComponent<PlayerHp>();

        PHP.RestarVida(Damage, new Vector3(0, 0, 0));
    }
}
