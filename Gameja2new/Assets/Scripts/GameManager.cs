using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    private GameManager gameManager;
    public int zombieToMedicine = 5;
    public int zombieLoopCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddZombieLoopCount()
    {
        zombieLoopCount = zombieLoopCount+1;
        

        if (zombieToMedicine == zombieLoopCount)
        {
            Debug.Log("hay medicina");
            
            zombieToMedicine++;
            zombieLoopCount = 0;
        }
        
    }

}
