using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AtaqueMeleEnemy_Anim : MonoBehaviour
{

    public UnityEvent ATK;
    public UnityEvent ATK_End;
    public UnityEvent Transportar;
    public UnityEvent Transportar_End;
    public UnityEvent Spell0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ATK_Mele()
    {
        ATK?.Invoke();
    }
    public void ATK_Endd()
    {
        ATK_End?.Invoke();
    }
    public void Transportar_0()
    {
        Transportar?.Invoke();
    }
    public void EndTransport()
    {
        Transportar_End?.Invoke();
    }

    public void Speel_0()
    {
        Spell0?.Invoke();
    }
}
