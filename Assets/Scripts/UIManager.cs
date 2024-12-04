using System.Collections;
using System.Collections.Generic;
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
            MainPanel.SetActive(true);
            GamePlayPanel.SetActive(false);
            // GameOverPanel.SetActive(false);
            // GameWinPanel.SetActive(false);
        }

    public void OnPlayButtonClicked()
        {
            MainPanel.SetActive(false);
            GamePlayPanel.SetActive(true);
        }

    public void ReplayBtnClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    public void DecreaseEnemyHUD(int EnemyCount)
        {
            EnemyHUD[EnemyCount-1].SetActive(false);
            
        }
}
