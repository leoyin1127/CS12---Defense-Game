using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyValues : MonoBehaviour
{
    //public Text HealthText;
    public int health;
    public GameObject DeathEffect;

    void Update()
    {
        EndGoal();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //HealthText.text = (int)health + "HP"; 
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