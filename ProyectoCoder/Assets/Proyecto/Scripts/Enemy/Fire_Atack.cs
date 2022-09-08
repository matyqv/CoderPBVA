using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Atack : MonoBehaviour
{

    public Transform Target;
    public bool Perseguir;

    public List<GameObject> Victima;

    public bool CanAtack=false;

   [SerializeField] private float T_Reatack;
   [SerializeField] private float Speed;

    public float T_Reatack1 { get => T_Reatack; set => T_Reatack = value; }
    public float Speed1 { get => Speed; set => Speed = value; }

    [SerializeField] private AudioClip Fire0;
    [SerializeField] private AudioClip Fire1;

    AudioSource As;

    // Start is called before the first frame update
    void Start()
    {
        As = GetComponent<AudioSource>();
        As.clip = Fire0;
        As.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Perseguir)
        {
            persiguiendo();
        }

        Atacar();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool player = other.CompareTag("Player");

        if (player)
        { Victima.Add(other.transform.gameObject); }
    }

    private void OnTriggerExit(Collider other)
    {
        bool player = other.CompareTag("Player");

        if (player)
        { Victima.Remove(other.transform.gameObject); }
    }

    public void AtacarOn()
    {
        CanAtack = true;
        As.PlayOneShot(Fire1, 0.6f);
    }

    public void Atacar()
    {
        if (CanAtack)
        {
            foreach (GameObject L in Victima)
            {
                PlayerHp PHP = L.GetComponent<PlayerHp>();
                PHP.RestarVida(1, transform.position * 0);
                Invoke("AtacarOn", T_Reatack1 * Time.deltaTime);
                As.PlayOneShot(Fire1, 0.6f);
                CanAtack = false;
            }
        }     
    }

    public void Destruir()
    {
        Destroy(this.gameObject);
    }

    void persiguiendo()
    {
        transform.LookAt(Target);

        Vector3 dir = -transform.position + Target.position;
        float Distancia = Vector3.Distance(Target.position, transform.position);

        if (Distancia > 0.8f)
        {
            transform.Translate(dir * Time.deltaTime*Speed1);
        }
    }
}
