using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Principal : MonoBehaviour
{
    [SerializeField] Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Jugar()
    {
        Anim.SetTrigger("play");
    }

    public void CargarEscena()
    {
        SceneManager.LoadScene("Escena_Inicial");
    }
}
