using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameObject endGamePanel;

    //아이템 박스 프리팹 및 맵 장애물 및 아이템 스폰 장소 관련 모음 변수들 

    public GameObject itemBox;

    public List<GameObject> obstacleList = new List<GameObject>();

    public List<GameObject> boxSpawnAreaList = new List<GameObject>();

    //////////////////////-------------------------------------------------------

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        
        int rand1 = Random.Range(0, obstacleList.Count);

        obstacleList[rand1].SetActive(true);

        for(int i =0; i < boxSpawnAreaList.Count; i++)
        {
           Instantiate(itemBox, boxSpawnAreaList[i].transform.position , Quaternion.identity);
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
