using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    public static WinLose WL;
    
    public GameObject losePanel;
    public GameObject winPanel;
    public Button restartButton;
    public Button winButton;
  

    private bool gameEnded = false;
    private GameObject healText;

    void Start()
    {
        WL = this;
        
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        
        restartButton.onClick.AddListener(RestartGame);
        winButton.onClick.AddListener(QuitGame);
        
        healText = GameObject.Find("Heal Info");
    }

    void Update()
    {
        if (gameEnded) return;
        

        if (HealthManager.HM.healthAmount <= 0)
        {
            Lose();
        }
    }

    public void Lose()
    {
        if (gameEnded) return;
        gameEnded = true;
        healText.SetActive(false);
        losePanel.SetActive(true);
        Time.timeScale = 0f; // Pauza gry
        AudioManager.AM.PlayLoseSound();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void Win()
    {
        if (gameEnded) return;

        gameEnded = true;
        healText.SetActive(false);
        winPanel.SetActive(true);
        Time.timeScale = 0f; // Pauza gry
        AudioManager.AM.PlayWinSound();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit called"); 
    }

   
}
