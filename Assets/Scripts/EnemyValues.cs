using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyValues : MonoBehaviour
{

    public int health;
    public GameObject DeathEffect;

    public void TakeDamage(int damage)
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

}