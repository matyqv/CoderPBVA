using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoDeEspada : MonoBehaviour
{
    public Transform Skin;
    public Animator anim;

    public float Damage;
   List<GameObject> Enemigos = new List<GameObject>();
    int XX;
    
    // Start is called before the first frame update
    void Awake()
    {
        PlayerStats.ActualizarValores += DamageValor;
        List();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void List()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") )
        {
            Enemigos.Add(other.transform.gameObject);
        }
    }   

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") )
        {
            Enemigos.Remove(other.transform.gameObject);
        }
    }
    
    public void ATK()
    {
        XX = 0;

        //if(Enemigos.ToArray().Length>0)
        {
            foreach (GameObject X in Enemigos)
            {
                if (X != null)
                {
                    X.GetComponent<EnemyHP>().RestarVida(Damage, Skin.forward);

                               if (X.GetComponent<EnemyHP>().HP1 <= 0) { Enemigos.Remove(X); }
                    //Revisar       
                }
            }
        }
    }

    public void DamageValor()
    {
        Debug.Log("Recibe PlayerStats.ActualizarValores desde " + name);
        Damage = GameManager.ATK * 0.2f;
    }
    private void OnDisable()
    {
        PlayerStats.ActualizarValores -= DamageValor;
    }
}
