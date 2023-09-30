using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;

    public bool isGameActive = true;
    //public int zombieToMedicine = 5;
    //public int zombieLoopCount = 0;

    public void GameOver()
    {
        gameOverUI.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //public void AddZombieLoopCount()
    //{
    //    zombieLoopCount = zombieLoopCount + 1;


    //    if (zombieToMedicine == zombieLoopCount)
    //    {
    //        Debug.Log("hay medicina");

    //        zombieToMedicine++;
    //        zombieLoopCount = 0;
    //    }
    //}
}
