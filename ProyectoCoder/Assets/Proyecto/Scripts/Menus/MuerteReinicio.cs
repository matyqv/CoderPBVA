using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuerteReinicio : MonoBehaviour
{       
    public GameObject CartelMuerte;
    public static MuerteReinicio instancia;

    public void Awake()
    {
            Debug.Log(instancia);
            PlayerHp.OnDead += GameOver;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetearEscena()
    {
        string Name = SceneManager.GetActiveScene().name;
        Debug.Log(Name);
        SceneManager.LoadScene(Name);
        GameManager.exp = 0;
        CartelMuerte.SetActive(false);
    }

    public void GameOver()
    {
        CartelMuerte.SetActive(true);
        Debug.Log("Recibe OnDead desde "+name);
    }

    public void OnDisable()
    {
        PlayerHp.OnDead -= GameOver;
    }
}
