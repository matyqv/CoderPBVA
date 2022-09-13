using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float HP;
    [SerializeField] float ATK;
    [SerializeField] float SPD;
    [SerializeField] int LVL;

    [SerializeField] Image BarraHP;
    [SerializeField] Image BarraATK;
    [SerializeField] Image BarraSPD;

    [SerializeField] TextMeshProUGUI Lvl;
    [SerializeField] TextMeshProUGUI nextlvl;

    public static event Action ActualizarValores;
    public static event Action RomperMeditacion;
    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {

        Lvl.text = "Lvl: " + GameManager.Lvl;
        nextlvl.text = "Next level: " + GameManager.Exp_Requisito;

        BarraHP.fillAmount = GameManager.HP / 10;
        BarraATK.fillAmount = GameManager.ATK / 10;
        BarraSPD.fillAmount = GameManager.SPD / 10;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CambiarHP(int X)
    {
        if (X > 0 && GameManager.Exp_Requisito<= GameManager.exp )
        {
            HP += X;
            GameManager.exp -= X*10;
            GameManager.Lvl += X;
            GameManager.Exp_Requisito = GameManager.Lvl*10;
        }


        if (X < 0 && HP>0)
        {
            HP += X;
            GameManager.exp += X * 10;
            GameManager.Lvl += X;
            GameManager.Exp_Requisito = GameManager.Lvl * 10;
        }

        Lvl.text = "Lvl: " + GameManager.Lvl;
        nextlvl.text = "Next level: " + GameManager.Exp_Requisito;


        BarraHP.fillAmount = (GameManager.HP + HP) / 10;
        BarraATK.fillAmount = (GameManager.ATK + ATK) / 10;
        BarraSPD.fillAmount = (GameManager.SPD + SPD) / 10;
    }

    public void CambiarATK(int X)
    {
        if (X > 0 && GameManager.Exp_Requisito <= GameManager.exp)
        {
            ATK += X;
            GameManager.exp -= X * 10;
            GameManager.Lvl += X;
            GameManager.Exp_Requisito = GameManager.Lvl * 10;
        }


        if (X < 0 && ATK > 0)
        {
            ATK += X;
            GameManager.exp += X * 10;
            GameManager.Lvl += X;
            GameManager.Exp_Requisito = GameManager.Lvl * 10;
        }

        Lvl.text = "Lvl: " + GameManager.Lvl;
        nextlvl.text = "Next level: " + GameManager.Exp_Requisito;


        BarraHP.fillAmount = (GameManager.HP+HP) / 10;
        BarraATK.fillAmount = (GameManager.ATK + ATK) / 10;
        BarraSPD.fillAmount = (GameManager.SPD+ SPD) / 10;
    }
    public void CambiarSpeed(int X)
    {
        if (X > 0 && GameManager.Exp_Requisito < GameManager.exp)
        {
            SPD += X;
            GameManager.exp -= X * 10;
            GameManager.Lvl += X;
            GameManager.Exp_Requisito = GameManager.Lvl * 10;
        }


        if (X < 0 && ATK > 0)
        {
            SPD += X;
            GameManager.exp += X * 10;
            GameManager.Lvl += X;
            GameManager.Exp_Requisito = GameManager.Lvl * 10;
        }

        Lvl.text = "Lvl: " + GameManager.Lvl;
        nextlvl.text = "Next level: " + GameManager.Exp_Requisito;

        BarraHP.fillAmount = (GameManager.HP + HP) / 10;
        BarraATK.fillAmount = (GameManager.ATK + ATK) / 10;
        BarraSPD.fillAmount = (GameManager.SPD + SPD) / 10;
    }
    public void Guardar()
    {
        GameManager.HP += HP;
        HP = 0;
        GameManager.ATK += ATK;
        ATK = 0;
        GameManager.SPD += SPD;
        SPD = 0;

        ActualizarValores?.Invoke();
        RomperMeditacion?.Invoke();
        Debug.Log("Enviar ActualizarValores desde " + name);
    }

    public void OnEnable()
    {

        Lvl.text = "Lvl: " + GameManager.Lvl;
        nextlvl.text = "Next level: " + GameManager.Exp_Requisito;

        BarraHP.fillAmount = GameManager.HP / 10;
        BarraATK.fillAmount = GameManager.ATK / 10;
        BarraSPD.fillAmount = GameManager.SPD / 10;
    }

}
