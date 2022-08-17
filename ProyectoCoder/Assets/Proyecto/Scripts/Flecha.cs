using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float speed;
    public float Damage;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destruir",300 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Mov();
    }

    void Mov()
    {
        transform.Translate(new Vector3(0,0,1) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHp>().RestarVida(Damage, transform.forward);
            Destruir();
        }
    }

    private void Destruir()
    {
        Destroy(this.gameObject);
    }
}
