using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoDeEspada : MonoBehaviour
{
    public Transform Skin;
    public Animator anim;

    [Range(1, 4)]
    public int Damage;

    public GameObject[] Enemigos;
    int XX;
    
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
        if (other.gameObject.CompareTag("Enemy") )
        {
            XX = 0;         

            // Arreglar Collider en Animacion
            foreach (GameObject X in Enemigos)
            {
                bool Delete = (Enemigos[XX] == other.transform.gameObject);
                bool Ok = (Enemigos[XX] == null);
                if (Ok) { Enemigos[XX] = other.transform.gameObject;break; }               
                Debug.Log(XX);
              
                XX++;
            }
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") )
        {
            XX = 0;
            foreach (GameObject X in Enemigos)
            {
                if (other.transform.gameObject== Enemigos[XX]) { Enemigos[XX] = null; }
                XX++;
            }
        }
    }

    public void ATK()
    {
        XX = 0;
        foreach (GameObject X in Enemigos)
        {
            bool Enemy=Enemigos[XX] != null;
            if (Enemy) { Enemigos[XX].GetComponent<EnemyHP>().RestarVida(Damage, Skin.forward); }
                XX++;
        }
    }
}
