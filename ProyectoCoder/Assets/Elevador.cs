using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Elevador : MonoBehaviour
{
    [SerializeField] Transform WP1;
    [SerializeField] Transform WP2;

    [SerializeField] Vector3 Pos1;
    [SerializeField] Vector3 Pos2;

    [SerializeField] bool Move;
    [SerializeField] float speed;

    public Transform Dentro;


    public UnityEvent Posicion1;
    public UnityEvent Posicion2;
    public UnityEvent Posicion3;
    // Start is called before the first frame update
    void Start()
    {
        Pos1 = transform.position;        
        Pos2 = transform.position + Pos2;        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Move) { move1(); }
        if ( Move) { move2(); }
    }

    void move1()
    {
        //PosicionBaja
        Pos2 = WP2.transform.position;
        Pos1 = WP1.transform.position;

        Vector3 direction = Pos1 - Pos2;
        float distancia = Vector3.Distance(Pos1, transform.position);
        if (distancia > 0.5f)
        {
            Posicion2?.Invoke();
            transform.Translate(direction * speed * Time.deltaTime);
            if (Dentro != null)
            { Dentro.Translate(direction * speed * Time.deltaTime); }
        }
        else
        {
            Posicion3?.Invoke(); 
        }
    }
    void move2()
    {

        //PosicionAlta
        Pos2 = WP2.transform.position;
        Pos1 = WP1.transform.position;

        Vector3 direction = Pos2 - Pos1;
        Debug.Log(direction);
        float distancia = Vector3.Distance(Pos2, transform.position);
        if (distancia > 0.5f)
        {
            Posicion2?.Invoke();
            transform.Translate(direction * speed * Time.deltaTime);
            if (Dentro != null)
            { Dentro.Translate(direction * speed * Time.deltaTime); }
        }
        else
        {
            Posicion1?.Invoke();
        }
    }

    public void OnOff()
    {
        bool onoff = !Move;
        Move = onoff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Dentro = other.transform;
            Invoke("OnOff", 50 * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Dentro = null;
        }
    }
}
