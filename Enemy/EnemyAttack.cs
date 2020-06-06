using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float rateOfFire = 2.0f;
    public GameObject enemyProjectile;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyAttack());
    }

    private void shoot()
    {
        Instantiate(enemyProjectile, transform.position, transform.rotation);
        StartCoroutine(enemyAttack());
    }

    IEnumerator enemyAttack()
    {
            yield return new WaitForSeconds(rateOfFire);
            shoot();
    }
}
