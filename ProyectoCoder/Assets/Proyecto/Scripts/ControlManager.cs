using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{

    public  KeyCode Up;
    public  KeyCode Down;
    public  KeyCode Left;
    public  KeyCode Right;

    public  KeyCode Attack;
    public  KeyCode Roll;
    public  KeyCode Interactuar;
    public  KeyCode Pocion;
    public  KeyCode GuardarArma;

    public  KeyCode Disparar;

    public AudioSource AS;
    public AudioSource Musica_AS;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Up1 = Up;
        GameManager.Down1 = Down;
        GameManager.Left1 = Left;
        GameManager.Right1= Right;
        GameManager.Attack1= Attack;
        GameManager.Roll1 = Roll;
        GameManager.Interactuar1 = Interactuar;
        GameManager.Pocion1 = Pocion;

        GameManager.AS1 = AS;
        GameManager.Musica_AS1 = Musica_AS;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Up1 = Up;
        GameManager.Down1 = Down;
        GameManager.Left1 = Left;
        GameManager.Right1 = Right;
        GameManager.Attack1 = Attack;
        GameManager.Roll1 = Roll;
        GameManager.Interactuar1 = Interactuar;
        GameManager.Pocion1 = Pocion;
        GameManager.GuardarArma1 = GuardarArma;
        GameManager.Disparar1= Disparar;

        GameManager.AS1 = AS;
        GameManager.Musica_AS1 = Musica_AS;
    }
}
