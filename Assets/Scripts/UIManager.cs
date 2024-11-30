using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject MainPanel;
    public GameObject GamePlayPanel;

    
    [Space(10)]
    public GameObject GameOverPanel;
    public GameObject GameWinPanel;

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
}
