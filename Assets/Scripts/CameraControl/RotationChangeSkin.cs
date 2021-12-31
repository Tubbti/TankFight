using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationChangeSkin : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(new Vector3(-28f,2f,-31f), new Vector3(0,1,0),Time.deltaTime * 12f);
    }
}
