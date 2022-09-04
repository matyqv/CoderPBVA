using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuerteReinicio : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
