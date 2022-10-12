using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bullet : MonoBehaviour
{

    [SerializeField] float Speed;
    [SerializeField] GameObject Bullet;

    [SerializeField] List<Transform> WP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        foreach (Transform X in WP)
        {
          GameObject Bala=  Instantiate(Bullet,X.transform.position,X.rotation);
        }
    }
}
