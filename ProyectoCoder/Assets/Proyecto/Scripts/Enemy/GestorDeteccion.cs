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

    [SerializeField] float detectado;
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

        bool isHit = Physics.BoxCast(Vision.transform.position, transform.lossyScale / 2, Vision.forward, out hit, Quaternion.identity, MaxDist);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(Vision.transform.position, Vision.forward * hit.distance);
            Gizmos.DrawWireCube(Vision.transform.position + Vision.forward * hit.distance, transform.lossyScale);
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
        { detectado -= 1 * Time.deltaTime; }
        EnemyMov.target = Target;
        float MaxDist = DistanciaDetectar;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(Vision.transform.position, transform.lossyScale / 2, Vision.forward, out hit, Quaternion.identity, MaxDist);
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
                    EnemyMov.zombiType = Enemy.Zombie.Perseguir;
                    detectado = 15;
                }
                else if (IsDestectable)
                {
                    bool ZombiePerseguir = EnemyMov.zombiType == Enemy.Zombie.Reposo;
                    Debug.Log("Detectado");
                    EnemyMov.zombiType = Enemy.Zombie.Mirar;
                    Vision.LookAt(DP.Player1);
                    EnemyMov.AsignarTarget(DP.Player1);
                }

                else if (!IsDestectable && !hit.transform.CompareTag("Player"))
                {
                    EnemyMov.zombiType = Enemy.Zombie.Reposo;
                }
            }

            else if (IsDestectable && !isHit)
            {
                bool ZombiePerseguir = EnemyMov.zombiType == Enemy.Zombie.Reposo;
                Debug.Log("puto");
                EnemyMov.zombiType = Enemy.Zombie.Mirar;
                EnemyMov.AsignarTarget(DP.Player1);
            }

            else if (!IsDestectable && !isHit)
            {
                EnemyMov.zombiType = Enemy.Zombie.Reposo;
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
                EnemyMov.zombiType = Enemy.Zombie.Perseguir;
            }
        }
    }
}
