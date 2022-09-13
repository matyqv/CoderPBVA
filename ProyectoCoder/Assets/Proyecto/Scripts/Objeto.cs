using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{

    public string NAME;
    public GameObject GO;
    public AudioClip GetObjeto;
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
        if (NAME != "Pocion")
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerKeys KY = other.GetComponent<PlayerKeys>();

                GameManager.AS1.PlayOneShot(GetObjeto, 1f);
                KY.AdherirKey(this.transform.gameObject);
            }
        }

        if (NAME == "Pocion")
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log(other.tag);
                PlayerKeys KY = other.GetComponent<PlayerKeys>();

                GameManager.AS1.PlayOneShot(GetObjeto, 1f);
                KY.AddObjeto(this.transform.gameObject);
            }
        }

    }
}
