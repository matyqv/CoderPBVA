using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke_Fire_Arack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvocarFuego()
    {
        GameObject ATK=transform.parent.GetComponent<Mago_Enemy>().FireAtack;
        ATK.GetComponent<Fire_Atack>().Target = transform.parent.GetComponent<Mago_Enemy>().TargetVisual;

        Instantiate(ATK, transform.position, Quaternion.identity);
    }
}
