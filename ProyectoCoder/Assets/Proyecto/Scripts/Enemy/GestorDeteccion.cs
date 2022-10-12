using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorDeteccion : MonoBehaviour
{
    [Header("Dinamicas")]

    public Transform TargetSonido;
    public Transform TargetVisual;
    [SerializeField] bool RastroPerdido;
    [SerializeField] float detectado;

    [Header("Estaticas")]

    [SerializeField] private Transform Brujula;
    [SerializeField] private Transform Head;
    [SerializeField] private Transform Vision;
    [Range(0, 30)]
    [SerializeField] Enemy EnemyMov;

    public bool testHit;
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
        else { Vision.LookAt(TargetSonido); }

        Detectar();
    }
    /*
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
    }*/

    void Detectar()
    {

        if (detectado<=0)
        {
            if (TargetVisual != null)
            {
                EnemyMov.AsignarTargetVisual(TargetVisual);
                EnemyMov.ZombiType = Enemy.Zombie.Perseguir;
            }
            if (TargetSonido != null && TargetVisual == null)
            {
                EnemyMov.AsignarTargetSonoro(TargetSonido);
                EnemyMov.ZombiType = Enemy.Zombie.Mirar;
            }
        }
        if (RastroPerdido)
        {
            detectado -= 5 * Time.deltaTime;
            if (detectado < 0)
            {
                EnemyMov.ZombiType = Enemy.Zombie.Reposo;
                TargetVisual = null;
            }
        }

    }

    public void DetectorSonido(Transform T)
    {
        TargetSonido = T;
    }

    public void DetectorVisual(Transform T)
    {
        TargetVisual = T;
        EnemyMov.AsignarTargetVisual(T);
        RastroPerdido = false;
        detectado = 40;
    }
    public void NoDetectorSonido()
    { TargetSonido = null; }

    public void NoDetectorVisual()
    {
        RastroPerdido=true;
    }
}
