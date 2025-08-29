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

    public GameObject enemyPrefab;

    public List<GameObject> obstacleList = new List<GameObject>();

    public List<GameObject> boxSpawnAreaList = new List<GameObject>();

    public List<GameObject> enemySpawnAreaList = new List<GameObject>();

    //////////////////////-------------------------------------------------------

    public int enemyUnitCount;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {

        enemyUnitCount = 0;

        //각각의 오브젝트에 대한 난수 생성 

        int rand1 = Random.Range(0, obstacleList.Count);

        int randBox = Random.Range(1, boxSpawnAreaList.Count);

        int randEnemy = Random.Range(1, enemySpawnAreaList.Count);

        //레벨 방해물 무작위 활성화 

        obstacleList[rand1].SetActive(true);

        //아이템 박스 무작위 생성 파트 

        for (int i = 0; i < randBox; i++)
        {
            Instantiate(itemBox, boxSpawnAreaList[i].transform.position, Quaternion.identity);
        }

        //적 무작위 생성 파트 

        for (int i = 0; i < randEnemy; i++)
        {
            Instantiate(enemyPrefab, enemySpawnAreaList[i].transform.position, Quaternion.identity);

            enemyUnitCount++;
        }

    }

    private void Update()
    {
        if(enemyUnitCount <= 0)
        {
            Invoke("ActiveEndGamePanel", 1.5f);
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

    public void ActiveEndGamePanel()
    {
        endGamePanel.SetActive(true);
    }

}
