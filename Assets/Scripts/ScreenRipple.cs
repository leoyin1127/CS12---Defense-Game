using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Coded By William
public class ScreenRipple : MonoBehaviour
{
    public float ZoomChange;
    public float SmoothChange;
    public float Minsize, Maxsize;

    private Camera cam;


    private void Start()
    {
        cam = GetComponent<Camera>();
        ZoomChange = 0.25f;
        SmoothChange = 1f;
        Minsize = 5.02f;
        Maxsize = 5.08f;

    }

    private void Update()
    {


        cam.orthographicSize -= ZoomChange * Time.deltaTime * SmoothChange;

        if (cam.orthographicSize < Minsize)
        {
            ZoomChange = -0.05f;
        }
        if (cam.orthographicSize > Maxsize)
        {
            ZoomChange = 0.05f;
        }

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, Minsize, Maxsize);
    }
}
