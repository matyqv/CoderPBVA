using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorDeteccion : MonoBehaviour
{
    [Header("Dinamicas")]

    public Transform Target;
    [SerializeField] float detectado;

    [Header("Estaticas")]

    [SerializeField] private Transform Brujula;
    [SerializeField] private Transform Head;
    [SerializeField] private Transform Vision;
    [SerializeField] private DetectarPlayer DP;
    [Range(0, 30)]
    [SerializeField] private float DistanciaDetectar;
    [SerializeField] Enemy EnemyMov;


    // Start is called before the first frame update
    void Start()
    {
        EnemyMov = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectado <= 0)
        {
            Vector3 Direccion = new Vector3(0, Head.eulerAngles.y, 0);
            Vision.transform.position = Head.transform.position;
            Vision.transform.eulerAngles = Direccion;
        }
        else { Vision.LookAt(Target); }

        Detectar();
    }
    private void OnDrawGizmos()
    {
        float MaxDist = DistanciaDetectar;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(Vision.transform.position, transform.lossyScale, Vision.forward, out hit, Quaternion.identity, MaxDist);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(Vision.transform.position, Vision.forward * hit.distance);
            Gizmos.DrawWireCube(Vision.transform.position + Vision.forward * hit.distance, transform.lossyScale*2);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(Vision.transform.position, Vision.forward * MaxDist);
        }
    }

    void Detectar()
    {
        if (detectado > 0)
        {
            detectado -= 1 * Time.deltaTime;
        }

        EnemyMov.Target1 = Target;
        float MaxDist = DistanciaDetectar;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(Vision.transform.position, transform.lossyScale, Vision.forward, out hit, Quaternion.identity, MaxDist);
        bool IsDestectable = DP.Player1 != null;

      

        if (detectado<=0)
        {
            if (isHit)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log("Visto");
                    Target = hit.transform;
                    EnemyMov.AsignarTarget(hit.transform);
                    EnemyMov.ZombiType = Enemy.Zombie.Perseguir;
                    detectado = 15;
                }
                else if (IsDestectable)
                {
                    bool ZombiePerseguir = EnemyMov.ZombiType == Enemy.Zombie.Reposo;
                    Debug.Log("Detectado");
                    EnemyMov.ZombiType = Enemy.Zombie.Mirar;
                    Vision.LookAt(DP.Player1);
                    EnemyMov.AsignarTarget(DP.Player1);
                }

                else if (!IsDestectable && !hit.transform.CompareTag("Player"))
                {
                    EnemyMov.ZombiType = Enemy.Zombie.Reposo;
                }
            }

            else if (IsDestectable && !isHit)
            {
                bool ZombiePerseguir = EnemyMov.ZombiType == Enemy.Zombie.Reposo;
                EnemyMov.ZombiType = Enemy.Zombie.Mirar;
                EnemyMov.AsignarTarget(DP.Player1);
            }

            else if (!IsDestectable && !isHit)
            {
                EnemyMov.ZombiType = Enemy.Zombie.Reposo;
            }
        }

        if (isHit)
        {
            if (hit.transform.CompareTag("Player"))
            {
                
                Debug.Log("Visto");
                detectado = 15;
                Target = hit.transform;
                EnemyMov.AsignarTarget(hit.transform);
                EnemyMov.ZombiType = Enemy.Zombie.Perseguir;               
             
            }
        }
    }
}
