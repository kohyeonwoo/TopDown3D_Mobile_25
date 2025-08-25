using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameObject endGamePanel;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
