using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaDeCamera : MonoBehaviour
{

    public Camera[] cameras;
    public int numeroCameras;
    public int NumeroMaximo;

    void Start()
    {
        NumeroMaximo = cameras.Length;
        numeroCameras = 1;

        foreach (Camera obj in cameras)
        {
            obj.gameObject.SetActive(false);
        }
        cameras[numeroCameras - 1].gameObject.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKeyDown("c") && numeroCameras < NumeroMaximo){
            numeroCameras++;
            foreach (Camera obj in cameras)
            {
                obj.gameObject.SetActive(false);
            }
            cameras[numeroCameras-1].gameObject.SetActive(true);
        }

        if (Input.GetKeyDown("c") && numeroCameras == NumeroMaximo){
            foreach (Camera obj in cameras)
            {
                obj.gameObject.SetActive(false);
            }
            cameras[numeroCameras - 1].gameObject.SetActive(true);
            numeroCameras = 0;
        }

    }


}


