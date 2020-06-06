using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    //Lives
    public int currentLives = 3;
    private SpawnPlayer spawnPlayerScript;

    public HealthBar healthBar;

    Animator shipAnimator;

    FireScript fireEffect;
    PlayerAttack playerShoot;


    // Start is called before the first frame update
    void Start()
    {
        shipAnimator = GetComponent<Animator>();

        healthBar = FindObjectOfType<HealthBar>();
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            currentLives -= 1;
            shipAnimator.SetTrigger("DeathAnimTrigger");

            fireEffect = FindObjectOfType<FireScript>();
            if(fireEffect != null)
            {
                fireEffect.DestroyFire();
            }
            playerShoot = FindObjectOfType<PlayerAttack>();
            if (playerShoot != null)
            {
                playerShoot.Destroy();
            }

            //GameEventScript.current.playerDeath();
            //Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            currentHealth -= 4;
            healthBar.setHealth(currentHealth);
        }
    }

    void DeathAnimEvent()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameEventScript.current.playerDeath();
    }

}
