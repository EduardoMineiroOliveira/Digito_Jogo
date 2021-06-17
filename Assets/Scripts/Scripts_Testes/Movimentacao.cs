using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{

    public Rigidbody rb;
    Vector3 moviment;
    public float moveSpeed = 5f;
    public Animator anim;

    public GameObject cam; // vai pegar o objeto camer
    public float camY; // vai criar uma variavel

    public bool cubeIsOnTheGround = true;

    void Update()
    {

        camY = cam.transform.rotation.eulerAngles.y;

        float xAxis = Input.GetAxisRaw("Horizontal");   
        float zAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xAxis, 0, zAxis) * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
        if(xAxis != 0 || zAxis != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if(xAxis == 1)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 5);
           transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, camY + 90, 0), Time.deltaTime * 5);
        }


        if (xAxis == -1)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 5);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, camY - 90, 0), Time.deltaTime * 5);
        }


        if (zAxis == 1)
        {
           //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5);
           transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, camY, 0), Time.deltaTime * 5);
        }


        if (zAxis == -1)
        {
           // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -180, 0), Time.deltaTime * 5);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, camY - 180, 0), Time.deltaTime * 5);
        }


        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && cubeIsOnTheGround)
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            anim.SetBool("InAir", true);
        }


    }
}
