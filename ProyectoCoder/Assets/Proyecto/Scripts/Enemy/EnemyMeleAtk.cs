using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleAtk : MonoBehaviour
{
    public Transform Skin;
    [Range(1, 4)]
    public int Damage;
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
        if (other.gameObject.CompareTag("Player"))
        {
            Skin = other.gameObject.transform;
            other.GetComponent<PlayerHp>().RestarVida(Damage, Skin.transform.forward);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Skin = null;
        }
    }
}
