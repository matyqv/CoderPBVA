using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsleraVertical : MonoBehaviour
{
    [SerializeField] bool subiendo;
    [SerializeField] Transform Player;
    [SerializeField] float Speed;
    [SerializeField] float DistanciaDetectar;
    [SerializeField] Transform Wp1;
    [SerializeField] Transform Wp2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null && subiendo ) { Player.GetComponent<CharacterController>().Move((Vector3.up* Speed * Time.deltaTime)+ (-transform.right* Speed*4* Time.deltaTime)); }
        Detectar();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            subiendo = true;
            Player = other.transform;
            Animator Anim = other.transform.GetChild(0).GetComponent<Animator>();

            Anim.SetBool("EV", subiendo);
            Player.GetComponent<MovimientoPlayer>().GravedadOn1 = !subiendo;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            subiendo = false;
            Player = other.transform;
            Animator Anim = other.transform.GetChild(0).GetComponent<Animator>();

            Anim.SetBool("EV", subiendo);
            Player.GetComponent<MovimientoPlayer>().GravedadOn1 = !subiendo;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform Skin = other.transform.GetChild(0).transform;
            Skin.position = Wp1.position;
            Skin.eulerAngles = Wp1.eulerAngles;
        }
    }

    private void OnDrawGizmos()
    {
        float MaxDist = DistanciaDetectar;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(transform.position, transform.lossyScale, Wp1.up, out hit, Quaternion.identity, MaxDist);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(Wp1.position, Wp1.up * hit.distance);
            Gizmos.DrawWireCube(Wp1.position + Wp1.up * hit.distance, transform.lossyScale*2);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(Wp1.position, Wp1.up * MaxDist);
        }     
    }
    void Detectar()
    {
        float MaxDist = DistanciaDetectar;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(transform.position, transform.lossyScale, Wp1.up, out hit, Quaternion.identity, MaxDist);
        if (isHit)
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                GetComponent<BoxCollider>().enabled = true;
            }
        }
      
    }

}
