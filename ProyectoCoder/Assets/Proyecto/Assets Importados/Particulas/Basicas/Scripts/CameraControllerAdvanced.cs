using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerAdvanced : MonoBehaviour
{
    public GameObject[] cameras;
    int currentCameraIndex;

    void Start()
    {
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);

        }
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentCameraIndex++;
            if (currentCameraIndex < cameras.Length)
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                cameras[currentCameraIndex].gameObject.SetActive(true);
                
            }
            else
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                currentCameraIndex = 0;
                cameras[currentCameraIndex].gameObject.SetActive(true);
                
            }
        }
    }

}
