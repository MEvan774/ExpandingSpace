using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHitPoint = 3;

    private void Start()
    {
        //GameEvents
        GameEventScript.current.onPlayerDeath += Disable;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            enemyHitPoint -= 1;
        }        
    }

    private void Update()
    {
        if (enemyHitPoint <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Disable()
    {
        Destroy(this.gameObject);
    }
}
