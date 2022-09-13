using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerKeys : MonoBehaviour
{
    public  Dictionary<string, GameObject> Keys_;
    public int Pocion;

    public static event Action<int> Pociones;
    public static event Action RevisarVida;
    // Start is called before the first frame update
    void Start()
    {
        Keys_ = new Dictionary<string, GameObject>();
        Pociones?.Invoke(Pocion);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown((GameManager.Pocion1)) )
        {
            int i = Pocion;
            if (i > 0)
            {
                consumirpocion();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
    }

   public void AdherirKey(GameObject Other)
   {
        Keys_.Add(Other.name, Other);
        Other.transform.gameObject.SetActive(false);
   }

    public void AddObjeto(GameObject Other)
    {
        Pocion += 1;
        Other.transform.gameObject.SetActive(false);
        Pociones?.Invoke(Pocion);
    }

    public void consumirpocion()
    {
        Pocion -= 1;
        if (GetComponent<PlayerHp>().HP < GameManager.HP)
        {
            GetComponent<PlayerHp>().HP += 1;
        }
        Pociones?.Invoke(Pocion);
        RevisarVida?.Invoke();

    }
}
