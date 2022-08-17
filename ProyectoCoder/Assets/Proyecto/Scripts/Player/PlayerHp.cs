using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [Range(1, 8)]
    public float HP;
    [Range(4, 8)]
    public int HPInicial;
    public MovimientoPlayer Player;
    public Animator Anim;
    
    public GameObject [] UnidadesVida;
    public GameObject UnidadDeVida;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<MovimientoPlayer>();
        Anim = Player.Skin.GetComponent<Animator>();
        UnidadesVida = new GameObject[8];
        HP = HPInicial;

        for (int i = 0; i < UnidadesVida.Length; i++)
        {
            UnidadesVida[i] = UnidadDeVida.transform.GetChild(i).transform.gameObject;
        }

        RevisarVida();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestarVida(float Daño, Vector3 V)
    {
        if (Player.vive)
        {
            Time.timeScale = 0.05f;
            Invoke("TimeIs1", 0.1f * Time.deltaTime);
            Anim.SetTrigger("GetHit");
            HP -= Daño;
            RevisarVida();
            Player.CC.Move(V * 1);
            if (HP <= 0)
            {
                Player.muerte();
            }
        }
    }

    void TimeIs1()
    {
        Time.timeScale = 1;
    }

    void RevisarVida()
    {
        Debug.Log("Vida REstadt");
        for (int i = 1; i < UnidadesVida.Length+1; i++)
        {
            if (i <= HPInicial) { UnidadesVida[i-1].SetActive(true); } else { UnidadesVida[i-1].SetActive(false); }
            Image HPX= UnidadesVida[i-1].transform.GetChild(0).GetComponent<Image>();
            if (i-1 < Mathf.RoundToInt(HP)) { HPX.enabled=true; } else { HPX.enabled = false; }
        }
    }
}
