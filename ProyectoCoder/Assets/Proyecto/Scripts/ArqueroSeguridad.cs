using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArqueroSeguridad : MonoBehaviour
{
    public GameObject Flecha;
    [Range(1, 200)]
    public float speed;
    [Range(1,4)]
    public float Damage;
    Transform Target;
    public DetectorReflector Detector;

    bool puedeDisparar=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Detector.Target != null)
        {          
            DispararFlecha();
        }
        if (Detector.Target == null)
        {
            Target = null;
        }
    }

    public void DispararFlecha()
    {
        if (puedeDisparar)
        {
            transform.LookAt(Detector.Target.position);
            GameObject flecha = Instantiate(Flecha, transform.position, transform.rotation);
            flecha.GetComponent<Flecha>().Damage = Damage;
            flecha.GetComponent<Flecha>().speed = speed;
            puedeDisparar = false;
            Invoke("DisparoHabilitado", 50 * Time.deltaTime);
        }
    }

    void DisparoHabilitado()
    {
        puedeDisparar = true;
    }
}
