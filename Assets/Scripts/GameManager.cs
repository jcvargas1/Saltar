using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController somePlayer;
    private Vector3 playerStartPoint;

    private ScoreManager someScoreManager;
    private PlatformDestroyer[] platformList;
    public DeathMenu someDeathScreen;


    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = somePlayer.transform.position;
        someScoreManager = FindObjectOfType<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        someScoreManager.scoreIncreasing = false;
        somePlayer.gameObject.SetActive(false);

        someDeathScreen.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        someDeathScreen.gameObject.SetActive(false);

        platformList = FindObjectsOfType<PlatformDestroyer>();

        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        somePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        somePlayer.gameObject.SetActive(true);
        someScoreManager.scoreCount = 0;
        someScoreManager.scoreIncreasing = true;

    }

}
