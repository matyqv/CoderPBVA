using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorDeteccion : MonoBehaviour
{
    public Transform Head;
    public Transform Vision;

    public DetectarPlayer DP;
    [Range(0, 30)]
    [SerializeField] private float DistanciaDetectar;
    Enemy EnemyMov;
    public Transform Target;
    public Transform Brujula;
    // Start is called before the first frame update
    void Start()
    {
        EnemyMov = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 Direccion = new Vector3(0, Head.eulerAngles.y, 0);
        Vision.transform.position = Head.transform.position;
        Vision.transform.eulerAngles = Direccion;

        Detectar();
    }
    private void OnDrawGizmos()
    {
        float MaxDist = DistanciaDetectar;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(transform.position, transform.lossyScale / 2, Vision.forward, out hit, Quaternion.identity, MaxDist);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vision.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + Vision.forward * hit.distance, transform.lossyScale);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, Vision.forward * MaxDist);
        }
    }

    void Detectar()
    {

        EnemyMov.target = Target;
        float MaxDist = DistanciaDetectar;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(transform.position, transform.lossyScale / 2, Vision.forward, out hit, Quaternion.identity, MaxDist);
        bool IsDestectable = DP.Player1 != null;

        if (isHit)
        {

            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Visto");
                EnemyMov.AsignarTarget(hit.transform);
                EnemyMov.zombiType = Enemy.Zombie.Perseguir;
            }
        }
        if (IsDestectable)
        {
            bool ZombiePerseguir = EnemyMov.zombiType == Enemy.Zombie.Reposo;
            Debug.Log("Detectado");
            Target = DP.Player1;

            if (ZombiePerseguir)
            {
                if (isHit)
                {
                    if (!hit.transform.CompareTag("Player"))
                    {
                        EnemyMov.zombiType = Enemy.Zombie.Mirar;
                        EnemyMov.AsignarTarget(Target);
                    }
                }
                else
                {
                    EnemyMov.zombiType = Enemy.Zombie.Mirar;
                    EnemyMov.AsignarTarget(Target);
                }
            }                  
        }

    }
}
