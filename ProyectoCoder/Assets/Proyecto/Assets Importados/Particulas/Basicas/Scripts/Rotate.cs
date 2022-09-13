using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotate;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((rotate)*speed*Time.deltaTime);
    }
}
