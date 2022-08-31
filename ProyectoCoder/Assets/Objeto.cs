using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{

    public string NAME;
    public GameObject GO;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {

         if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.tag);
            PlayerKeys KY=other.GetComponent<PlayerKeys>();
            
            KY.AdherirKey(this.transform.gameObject);
        }
    }
}
