using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float velocidademovi = 20.0f;
    public float alturasalto = 50.0f;
    private Vector3 posit;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        posit = transform.position; // recebendo os tres eixos
        posit.x += velocidademovi * Input.GetAxis("Horizontal") * Time.deltaTime;
        posit.z += velocidademovi * Input.GetAxis("Vertical") * Time.deltaTime;
        posit.y += alturasalto * Input.GetAxis("Jump") * Time.deltaTime;

        transform.position = posit;


    }


}
