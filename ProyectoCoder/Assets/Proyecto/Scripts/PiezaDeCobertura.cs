using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaDeCobertura : MonoBehaviour
{
    
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
            other.tag = "Playerr";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Playerr"))
        {
            other.tag = "Player";
        }
    }
}
