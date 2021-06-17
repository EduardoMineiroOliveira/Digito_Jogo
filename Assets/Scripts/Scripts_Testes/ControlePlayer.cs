using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class ControlePlayer : MonoBehaviour
{

    private string turnInputAxis = "Horizontal";
    private Animator anim;

   
    [Tooltip("Rate per seconds holding down input")]
    public float rotationRate = 360; //Valor para velocidade da rotação do player


   void Start()
    {
        anim = GetComponent<Animator>();
    }




    void Update()
    {

        float turnAxis = Input.GetAxis(turnInputAxis);


        ApplyInput(turnAxis);

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");


        anim.SetFloat("Horizontal" , inputX);
        anim.SetFloat("Vertical" , inputY);
       

       // float turnAxis = Input.GetAxis(turnInputAxis);

       // ApplyInput(turnAxis);

        //anim.SetFloat("Horizontal", Input.GetAxis("Horizontal")); //Atribui o valor da variável inputX para o parâmetro Horizontal do controle de animação
        //anim.SetFloat("Vertical", Input.GetAxis("Vertical")); //Atribui o valor da variável inputY para o parâmetro Vertical do controle de animação

        //Correndo ou não
      //  if (Input.GetKey(KeyCode.LeftShift))
      //      anim.SetBool("Run", true); //Segurando o shift esquerdo a bool Run do controle de animação recebe true
      //  else
        //    anim.SetBool("Run", false); //Soltando o shift esquerdo a bool Run do controle de animação recebe false
    }

   void ApplyInput(float turnInput)
    {
        Turn(turnInput);
    }

   void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}