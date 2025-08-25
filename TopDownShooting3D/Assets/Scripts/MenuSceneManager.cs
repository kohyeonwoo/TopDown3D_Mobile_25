using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuSceneManager : MonoBehaviour
{
    
    public void GoGameScene()
    {
        SceneManager.LoadScene("StartScene");
    }

}
