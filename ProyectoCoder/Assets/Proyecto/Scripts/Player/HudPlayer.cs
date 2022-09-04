using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudPlayer : MonoBehaviour
{
    public TextMeshProUGUI Exp;
    public Text Button_Att;
    public Text Button_Roll;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Exp.text = GameManager.exp+"";
        Button_Att.text = GameManager.Attack1.ToString();
        Button_Roll.text = GameManager.Roll1.ToString();
    }
}
