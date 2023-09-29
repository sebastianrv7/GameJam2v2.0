using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] 
    GameObject[] zombie;

    [SerializeField]
    float spawnRate = 5f;
    [SerializeField]
    float spawnRadius = 10f;

    Timer timer;
    Vector2 playerPos;

    private void Start()
    {
        // CAMBIAR LLAMADO DE TIMER PARA INTEGRACIÓN
        timer = FindObjectOfType<Timer>().GetComponent<Timer>();
        
        StartCoroutine(SpawnZombies());
    }

    private void FixedUpdate()
    {
        GetPlayerPosition();
    }

    Vector2 RandomSpawnPosition()
    {
        float distance = Random.Range(5f, 10f);
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector2 relativePos = new (Mathf.Cos(angle) * distance, Mathf.Sin(angle) * distance);
        Vector2 randomPos = relativePos + playerPos;

        return randomPos;
    }

    IEnumerator SpawnZombies()
    {
        while (timer.isRunning)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(zombie[0], RandomSpawnPosition(), Quaternion.identity);
        }
    }

    void GetPlayerPosition()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
