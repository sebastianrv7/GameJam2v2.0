using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text timerText;
    public float elapsedTime = 60f; // Inicializar el tiempo con 2 minutos (120 segundos)
    public bool isRunning = true; // Comenzar el temporizador inmediatamente
    private GameManager gameManager;


    private void Start()
    {
        
        UpdateTimerText(elapsedTime); // Mostrar el tiempo inicial
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void Update()
    {
        if (isRunning)
        {
            elapsedTime -= Time.deltaTime;

            if (elapsedTime <= 0f)
            {
                elapsedTime = 0f;
                isRunning = false;
            }

            UpdateTimerText(elapsedTime);
        }
        ItsOver();


    }
    
    private void UpdateTimerText(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int centiseconds = Mathf.FloorToInt((timeInSeconds * 100) % 100);

        string timerFormat;

        if (minutes > 0)
        {
            timerFormat = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, centiseconds);
        }
        else
        {
            timerFormat = string.Format("{0:00}:{1:00}", seconds, centiseconds);
        }

        timerText.text = timerFormat;
    }

    public void AddTime()
    {
        elapsedTime += 30f;
    }

    public void LessTime()
    {
        elapsedTime -= 30f;
    }

    private void ItsOver()
    {
        if (elapsedTime <= 0)
        {
            gameManager.GameOver();
            
        }
    }
    
}
