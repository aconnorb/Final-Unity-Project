using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public Text scoreText;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private int score;


    public GameObject hazard2;
    public Vector3 spawnValues2;
    public int hazardCount2;
    public float spawnWait2;
    public float startWait2;
    public float waveWait2;

    void Start()
    {
        StartCoroutine(SpawnWaves());
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves2());

    }

    IEnumerator SpawnWaves2()
    {
        yield return new WaitForSeconds(startWait2);
        while (true)
        {
            for (int i = 0; i < hazardCount2; i++)
            {
                Vector3 spawnPosition2 = new Vector3(Random.Range(-spawnValues2.x, spawnValues2.x), Random.Range(spawnValues2.y, 0), spawnValues2.z);
                Quaternion spawnRotation2 = Quaternion.identity;
                Instantiate(hazard2, spawnPosition2, spawnRotation2);
                yield return new WaitForSeconds(spawnWait2);
            }
            yield return new WaitForSeconds(waveWait2);
        }
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Round1");
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Round1");
        }




    }


    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if (score >= 100)
        {
            SceneManager.LoadScene("Round2");
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
}
