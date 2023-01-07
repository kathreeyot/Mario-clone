using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;

public class Level02 : MonoBehaviour
{

    
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;
    
    public GameObject pauseMenuScreen;
    private void Awake()
    {

        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        

    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = numberOfCoins.ToString();

        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }

    }
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ResumeGame()
    {
        pauseMenuScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);

    }

}
