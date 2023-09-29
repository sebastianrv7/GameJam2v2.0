using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private bool disparando = false;

    void Start()
    {
        // Obtén una referencia al componente Animator del GameObject.
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Detecta si se presiona un botón o se realiza alguna acción para iniciar la animación de disparo.
        if (Input.GetButtonDown("Fire1") && !disparando)
        {
            // Cambia la variable "disparando" en el Animator para activar la transición a la animación de disparo.
            animator.SetBool("shoot", true);
            disparando = true;
        }
    }
}
