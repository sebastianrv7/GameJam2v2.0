using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject balaPrefab; // Arrastra aquí el Prefab de la bala en el Inspector
    public float tiempoEntreDisparos = 0f; // Tiempo en segundos entre disparos
    private float tiempoUltimoDisparo = 0f; // Guarda el tiempo del último disparo

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            Shoot();
            tiempoUltimoDisparo = Time.time; // Actualiza el tiempo del último disparo


        }
    }

    void Shoot()
    {
        // Obtener la posición de la arma
        Vector3 posicionArma = transform.position;

        // Obtener la rotación de la arma (misma dirección que la del arma)
        Quaternion rotacionArma = transform.rotation;

        // Instanciar una bala en la posición y con la rotación de la arma
        GameObject bala = Instantiate(balaPrefab, posicionArma, rotacionArma);

        // Ajustar aquí la velocidad de la bala o cualquier otra propiedad necesaria
        // por ejemplo, puedes agregar un componente Rigidbody2D y aplicar una velocidad inicial a la bala.
    }
}
