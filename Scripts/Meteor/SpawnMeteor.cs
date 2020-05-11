using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    bool gameStart = true;

    public GameObject MeteorPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height * 4, Camera.main.transform.position.z));
        StartCoroutine(meteorWave());
    }

    private void spawnMeteor()
    {
        GameObject meteor = Instantiate(MeteorPrefab) as GameObject;
        meteor.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator meteorWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnMeteor();
        }
    }
}
