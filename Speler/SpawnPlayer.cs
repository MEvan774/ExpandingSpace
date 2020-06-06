using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject player;
    private Vector2 screenBounds;
    //bool playerStart = false;

    //ProgressBar
    public GameObject progressBar;

    //lifes
    public LifeUI lifeUi;
    private float playerLifes = 3;

    //Respawn
    public float respawnTime = 2.0f;

    //Meteorite Spawner
    SpawnMeteor meteoriteSpawner;

    //Enemies
    EnemyHealth enemy;

    SpawnPlayer thisScript;

    void Start()
    {
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //GameEvents
        GameEventScript.current.onPlayerDeath += playerIsDeath;

        lifeUi = FindObjectOfType<LifeUI>();
        lifeUi.setCurrentLifes(playerLifes);


    }

    public void spawn()
    {
        player = Instantiate(playerPrefab) as GameObject;

        //Spawn position
        player.transform.position = new Vector2(screenBounds.x - 4, screenBounds.y - 1);
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.Space) && playerStart == false)
        //{
            //playerStart = true;

        //}

    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(respawnTime);

        lifeUi.setCurrentLifes(playerLifes);

        //Spawn player and position
        GameObject player = Instantiate(playerPrefab) as GameObject;
        playerPrefab.transform.position = new Vector2(screenBounds.x - 4, screenBounds.y - 1);

        ProgressBar progressbar = FindObjectOfType<ProgressBar>();
        progressbar.StartProgress();

        SpawnMeteor meteoriteSpawner = FindObjectOfType<SpawnMeteor>();
        meteoriteSpawner.setFalse();
    }

    public void playerIsDeath()
    {
        if (playerLifes >= 1)
        {
            playerLifes -= 1;
            Debug.Log("Player Death");

            //remove enemies
            EnemyHealth enemy = FindObjectOfType<EnemyHealth>();
            enemy.Disable();

            if (thisScript == null)
            {
                StartCoroutine(respawn());
            }

        }
        else if (playerLifes <= 0)
        {
            progressBar.gameObject.SetActive(false);
            Debug.Log("Game Over");
            LevelUIManager levelManager = FindObjectOfType<LevelUIManager>();
            levelManager.GameOver();
        }
    }
}
