using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private bool disparando = false;
    public float tiempoEntreDisparos = 1f; // Tiempo en segundos entre disparos
    private float tiempoUltimoDisparo = 0f; // Guarda el tiempo del último disparo

    void Start()
    {
        // Obtén una referencia al componente Animator del GameObject.
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        walkAnimation();
        shootAnimation();




    }

    private void shootAnimation()
    {
        // Detecta si se presiona un botón o se realiza alguna acción para iniciar la animación de disparo.
        if (Input.GetMouseButtonDown(0) && Time.time >= tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            // Cambia la variable "disparando" en el Animator para activar la transición a la animación de disparo.
            animator.SetBool("shoot", true);
            tiempoUltimoDisparo = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {

            animator.SetBool("shoot", false);

        }
    }

    private void walkAnimation()
    {
        if (Input.GetAxis("Vertical")!=0 || Input.GetAxis("Horizontal")!=0)
        {
            animator.SetBool("Walking", true);
        }else animator.SetBool("Walking", false);
    }


}
