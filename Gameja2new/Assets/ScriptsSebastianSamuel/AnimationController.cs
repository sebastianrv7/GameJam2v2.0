using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private bool disparando = false;

    void Start()
    {
        // Obt�n una referencia al componente Animator del GameObject.
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Detecta si se presiona un bot�n o se realiza alguna acci�n para iniciar la animaci�n de disparo.
        if (Input.GetButtonDown("Fire1") && !disparando)
        {
            // Cambia la variable "disparando" en el Animator para activar la transici�n a la animaci�n de disparo.
            animator.SetBool("shoot", true);
            disparando = true;
        }
    }
}
