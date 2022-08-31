using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerBasic : MonoBehaviour
{
    public GameObject cam1, cam2, cam3, cam4, cam5;
    int indexNumber;
    void Start()
    {
        indexNumber=1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            indexNumber++;
        }



        if(indexNumber==1)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
        }
        if(indexNumber==2)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
        }
        if(indexNumber==3)
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            cam4.SetActive(false);
            cam5.SetActive(false);
        }
        if(indexNumber==4)
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(true);
            cam5.SetActive(false);
        }
        if(indexNumber==5)
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(true);
        }
        if(indexNumber==6)
        {
            indexNumber=1;
        }
        
    }
}
