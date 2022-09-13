using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHp : MonoBehaviour
{
    [Range(1, 10)]
    public float HP;
    [Range(4, 10)]
    public int HPInicial;
    float HPInicial_;
    public MovimientoPlayer Player;
    public Animator Anim;
    
    [SerializeField] private Image UnidadDeVida;
    [SerializeField] private Image UnidadDeVidaBase;

    public static event Action OnDead;
    // Start is called before the first frame update

    void Awake()
    {
        PlayerStats.ActualizarValores += RevisarVida;
        PlayerKeys.RevisarVida += RevisarVida;
    }
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

    public void RestarVida(float Daño, Vector3 V)
    {
        if (Player.Vive)
        {
            Time.timeScale = 0.05f;
            Invoke("TimeIs1", 0.2f * Time.deltaTime);
            Anim.SetTrigger("GetHit");
            HP -= Daño;
            RevisarVida();
            Player.CC.Move(V * 1);
            if (HP <= 0)
            {
                OnDead?.Invoke();
                Debug.Log("Envia OnDead desde " + name);
            }
        }
    }

    void TimeIs1()
    {
        Time.timeScale = 1;
    }

    void RevisarVida()
    {
        HPInicial_ = GameManager.HP;
        float Tamaño = HPInicial_ / 10;
        UnidadDeVida.fillAmount = (HP / 10);
        UnidadDeVidaBase.fillAmount = Tamaño;

        //no simpre se llama desde este metodo
        Debug.Log("Recibe PlayerStats.ActualizarValores Desde " + name);
    }

    private void OnDisable()
    {
        PlayerStats.ActualizarValores -= RevisarVida;
        PlayerKeys.RevisarVida -= RevisarVida;
    }
}
