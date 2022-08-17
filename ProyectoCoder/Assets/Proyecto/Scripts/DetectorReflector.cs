using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorReflector : MonoBehaviour
{
    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Target = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Target = null;
        }
        if (other.CompareTag("Playerr"))
        {
            Target = null;
        }
    }
}
