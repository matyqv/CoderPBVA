using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbeExperiencia : MonoBehaviour
{

    public int Experiencia;

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
        bool player = other.CompareTag("Player")|| other.CompareTag("Playerr");

        if (player)
        {
            Exp_Suma();
        }
    }

    void Exp_Suma()
    {
        GameManager.exp += Experiencia;
        GameManager.exp = Mathf.RoundToInt(GameManager.exp);
        Destroy(gameObject);
    }
}
