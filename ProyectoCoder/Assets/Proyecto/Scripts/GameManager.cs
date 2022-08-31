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

    private static KeyCode Up;
    private static KeyCode Down;
    private static KeyCode Left;
    private static KeyCode Right;

    private static KeyCode Attack;
    private static KeyCode Roll;
    private static KeyCode Interactuar;

    public static KeyCode Up1 { get => Up; set => Up = value; }
    public static KeyCode Down1 { get => Down; set => Down = value; }
    public static KeyCode Left1 { get => Left; set => Left = value; }
    public static KeyCode Right1 { get => Right; set => Right = value; }
    public static KeyCode Attack1 { get => Attack; set => Attack = value; }
    public static KeyCode Roll1 { get => Roll; set => Roll = value; }
    public static KeyCode Interactuar1 { get => Interactuar; set => Interactuar = value; }


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

    // Update is called once per frame
    void Update()
    {
        
    }

}
