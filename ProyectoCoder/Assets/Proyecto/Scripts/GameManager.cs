using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float exp;
    public float Exp;
    public static GameManager Instance;
    public bool dontDestroyOnLoad;
    public static Dictionary<string,GameObject> Keys_;

    private static AudioSource AS;
    private static AudioSource Musica_AS;

    private static KeyCode Up;
    private static KeyCode Down;
    private static KeyCode Left;
    private static KeyCode Right;

    private static KeyCode Attack;
    private static KeyCode Roll;
    private static KeyCode Interactuar;
    private static KeyCode Pocion;
    private static KeyCode GuardarArma;
    private static KeyCode Disparar;

    public static KeyCode Up1 { get => Up; set => Up = value; }
    public static KeyCode Down1 { get => Down; set => Down = value; }
    public static KeyCode Left1 { get => Left; set => Left = value; }
    public static KeyCode Right1 { get => Right; set => Right = value; }
    public static KeyCode Attack1 { get => Attack; set => Attack = value; }
    public static KeyCode Roll1 { get => Roll; set => Roll = value; }
    public static KeyCode Interactuar1 { get => Interactuar; set => Interactuar = value; }
    public static AudioSource AS1 { get => AS; set => AS = value; }
    public static AudioSource Musica_AS1 { get => Musica_AS; set => Musica_AS = value; }
    public static KeyCode Pocion1 { get => Pocion; set => Pocion = value; }
    public static KeyCode GuardarArma1 { get => GuardarArma; set => GuardarArma = value; }
    public static KeyCode Disparar1 { get => Disparar; set => Disparar = value; }

    public static float ATK;
    public static float HP;
    public static float SPD;
    public static float Exp_Requisito;
    public static int  Lvl;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        { Destroy(gameObject); }
    }

    private void Start()
    {
        AS1 = GetComponentInChildren<AudioSource>();
        if (HP == 0)
        { HP = 4; }
        if (ATK == 0)
        { ATK = 4; }
        if (SPD == 0)
        { SPD = 4; }
        if (Lvl == 0)
        { Lvl = 1; }
        Exp_Requisito = Lvl * 10;
    }

    // Update is called once per frame
    void Update()
    {
    }

}
