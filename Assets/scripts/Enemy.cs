using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject smoke;
    [SerializeField] float takeDamage = 10f;
    [SerializeField] float deathDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(explosion, transform);
            Destroy(gameObject, deathDelay);
        }
        else if (10 <= health && health <= 20) {
            Instantiate(smoke, transform);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        health -= takeDamage; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform);
        Destroy(gameObject, deathDelay);
    }
}
