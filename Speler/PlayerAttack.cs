using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject playerProjectile;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    private void Start()
    {
        //GameEvents
        GameEventScript.current.onPlayerDeath += Destroy;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(playerProjectile, transform.position, transform.rotation);
    }
}
