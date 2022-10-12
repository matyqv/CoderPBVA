using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConoVision : MonoBehaviour
{

    [SerializeField] Transform PersonajeVisto;
    [SerializeField] GestorDeteccion GD;
    // Start is called before the first frame update
    void Start()
    {
        Alerta(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        bool IsPlayer = other.CompareTag("Player")|| other.CompareTag("Playerr");

        if (IsPlayer)
        {
            PersonajeVisto = other.transform;
            GD.DetectorVisual(PersonajeVisto);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bool IsPlayer = other.CompareTag("Player") || other.CompareTag("Playerr");

        if (IsPlayer)
        {
            PersonajeVisto = null;
            GD.NoDetectorVisual();
        }
    }

    public void Alerta(bool X)
    {
        Transform T = transform.parent.GetComponent<Transform>();
        if (X != true) { T.localScale = new Vector3(1.4f, 0.7f, 1.4f); }
        if (X == true) { T.localScale = new Vector3(1.8f, 1.8f, 1.4f); }
    }
}
