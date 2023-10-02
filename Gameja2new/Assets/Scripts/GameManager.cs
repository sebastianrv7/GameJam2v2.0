using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    private GameObject gun;

    private void Start()
    {
        gun = GameObject.Find("GunFinal");
    }

    public bool isGameActive = true;
    //public int zombieToMedicine = 5;
    //public int zombieLoopCount = 0;

    public void GameOver()
    {
        gameOverUI.gameObject.SetActive(true);
        isGameActive = false;
        gun.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Epilogue()
    {
        SceneManager.LoadScene("Ending");
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
