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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}