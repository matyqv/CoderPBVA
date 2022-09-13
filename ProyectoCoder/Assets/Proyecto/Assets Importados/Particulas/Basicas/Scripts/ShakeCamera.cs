using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cmVirtualCam;
    public float shakeTimer;
    void Awake()
    {
        //cmVirtualCam = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();
        
    }
    public void ShakeTime(float time)
    {
        shakeTimer = time;

    }
    public void ShakeNow(float intensity)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
        cmVirtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        ShakeTime(shakeTimer);
    }
    
    void Update()
        {
            if(shakeTimer > 0)
            {
                shakeTimer -= Time.deltaTime;
                if (shakeTimer <= 0)
                {
                    //timeout
                    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    cmVirtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

                }
            }
        }
}
