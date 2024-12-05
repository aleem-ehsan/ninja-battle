using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject MainPanel;
    public GameObject GamePlayPanel;
    public GameObject GameOverPanel;
    public GameObject GameWinPanel;

    [Space(10)]
    public GameObject[] EnemyHUD;

    public bool isGameStart { get; private set; } = false; // Track game state

    private void Awake()
    {
        print("UI Manager Awake");
        instance = this;
    }

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        isGameStart = false; // Game starts as inactive
        MainPanel.SetActive(true);
        GamePlayPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameWinPanel.SetActive(false);
    }

    public void OnPlayButtonClicked()
    {
        MainPanel.SetActive(false);
        GamePlayPanel.SetActive(true);
        isGameStart = true; // Set game to active when play starts
    }

    public void ReplayBtnClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DecreaseEnemyHUD(int EnemyCount)
    {
        EnemyHUD[EnemyCount - 1].SetActive(false);
    }

    public void GameLoose()
    {
        Time.timeScale = 0;
        isGameStart = false; // Game is no longer active
        GamePlayPanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }

    public void GameWin()
    {
        Time.timeScale = 0;
        isGameStart = false; // Game is no longer active
        GamePlayPanel.SetActive(false);
        GameWinPanel.SetActive(true);
    }
}
