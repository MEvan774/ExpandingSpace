using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventOut : MonoBehaviour
{

    public void SpawnStartEvent()
    {
        SpawnPlayer spawner = FindObjectOfType<SpawnPlayer>();
        spawner.spawn();
    }

    void EndAnimEvent()
    {
        SpawnMeteor meteorSpawner = FindObjectOfType<SpawnMeteor>();
        meteorSpawner.setFalse();

        this.gameObject.SetActive(false);
    }
}
