using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [Range(1, 10)]
    public float HP;
    [Range(4, 10)]
    public int HPInicial;
    float HPInicial_;
    public MovimientoPlayer Player;
    public Animator Anim;
    
    public Image UnidadDeVida;
    public Image UnidadDeVidaBase;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<MovimientoPlayer>();
        Anim = Player.Skin.GetComponent<Animator>();
        HP = HPInicial;

        RevisarVida();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestarVida(float Da�o, Vector3 V)
    {
        if (Player.Vive)
        {
            Time.timeScale = 0.05f;
            Invoke("TimeIs1", 0.1f * Time.deltaTime);
            Anim.SetTrigger("GetHit");
            HP -= Da�o;
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
        HPInicial_ = HPInicial;
        float Tama�o = HPInicial_ / 10;
        UnidadDeVida.fillAmount = (HP / 10);
        UnidadDeVidaBase.fillAmount = Tama�o;
        Debug.Log("Vida REstadt");
    }
}
