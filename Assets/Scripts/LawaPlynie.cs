using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawaPlynie : MonoBehaviour
{
    public float X = 0.1f;
    public float Y = 0.1f;

    // Update is called once per frame
    void Update()
    {
        float OffsetX = Time.time * X;
        float OffsetY = Time.time * Y;
        
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }
}
