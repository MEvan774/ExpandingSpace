using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnMeteor : MonoBehaviour
{
    bool Tutorial = false;

    public GameObject MeteorPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    public GameObject EnemyPrefab;
    public float enemyRespawnTime = 6.0f;

    private bool pauseSpawn = true;

    void Start()
    {
        GameEventTutorial.current.tutorialStart += TutorialStart;


        GameEventScript.current.onPlayerDeath += setTrue;

        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height * 4, Camera.main.transform.position.z));
        if (!Tutorial)
        {
            StartCoroutine(meteorWave());
            StartCoroutine(enemyWave());
        }

    }

    private void TutorialStart()
    {
        Tutorial = true;
    }

    public void TutorialEnd()
    {
        Tutorial = false;
        StartCoroutine(meteorWave());
        StartCoroutine(enemyWave());
    }

    private void setTrue()
    {
        pauseSpawn = true;
    }

    public void setFalse()
    {
        pauseSpawn = false;

        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height * 4, Camera.main.transform.position.z));
        if (!Tutorial)
        {
            StartCoroutine(meteorWave());
            StartCoroutine(enemyWave());
        }
    }

    private void spawnMeteor()
    {
            GameObject meteor = Instantiate(MeteorPrefab) as GameObject;
            meteor.transform.position = new Vector2(screenBounds.x * 15, Random.Range(-screenBounds.y, screenBounds.y));
    }


    private void spawnEnemy()
    {
        GameObject enemy = Instantiate(EnemyPrefab) as GameObject;
        enemy.transform.position = new Vector2(screenBounds.x * 15, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator meteorWave()
    {
        while (pauseSpawn == false)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnMeteor();
        }
    }

    IEnumerator enemyWave()
    {
        while (pauseSpawn == false)
        {
            yield return new WaitForSeconds(enemyRespawnTime);
            spawnEnemy();
        }
    }
}
