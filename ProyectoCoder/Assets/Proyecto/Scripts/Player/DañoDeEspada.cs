using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoDeEspada : MonoBehaviour
{
    public Transform Skin;
    public Animator anim;

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
        if (other.gameObject.CompareTag("Enemy") && anim.GetCurrentAnimatorStateInfo(0).IsTag("AT"))
        {
            other.GetComponent<EnemyHP>().RestarVida(Damage, Skin.forward);
        }
    }
 
}
