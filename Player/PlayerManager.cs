using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cinemachine;
public class PlayerManager : MonoBehaviour
{
    
    
    public static bool GameComplete;
    public GameObject GamecompleteScreen;
    public static bool isGameOver;
    
    public GameObject gameOverScreen;
    public static int numberOfCoins;
    
    public TextMeshProUGUI coinsText;
    
    public static Vector2 lastCheckPointPos = new Vector2(10.51f, 202.61f);
    
    public GameObject pauseMenuScreen;
    int characterIndex;
   
    public GameObject[] playerPrefabs;
    
    public CinemachineVirtualCamera VCam;
    public  void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        isGameOver = false;
        GameComplete = false;
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
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
            pauseMenuScreen.SetActive(false);
            gameOverScreen.SetActive(true);
            Time.timeScale = 1;
            
        }
        if (GameComplete)
        {
            pauseMenuScreen.SetActive(false);
            Time.timeScale = 1;
            GamecompleteScreen.SetActive(true); 
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

        AudioManager.instance.Play("Click");
        Time.timeScale = 0;
            pauseMenuScreen.SetActive(true);
        
        
        
    }
    public static void NextLevel()
    {
        
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        lastCheckPointPos = new Vector2(10.51f, 202.61f);

    }
    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);



    }

    





}



