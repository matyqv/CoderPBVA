using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatallaConJefe : MonoBehaviour
{

    public GameObject Cam1;
    public GameObject CamJefe;
    public GameObject BidaJEfe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().isTrigger = false;
            Cam1.SetActive(false);
            CamJefe.SetActive(true);
            BidaJEfe.SetActive(true);
        }
    }
}
