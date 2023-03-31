using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyValues : MonoBehaviour
{

    public float health;
    public GameObject DeathEffect;

    void Update()
    {
        EndGoal();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            die();
        }

    }

    void die()
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void EndGoal()
    {
        if (transform.position.x >= 6.8f)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}