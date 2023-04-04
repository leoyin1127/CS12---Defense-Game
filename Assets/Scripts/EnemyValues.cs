using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;



public class EnemyValues : MonoBehaviour
{

    private Enemy _enemy; 


    public float health;
    public GameObject DeathEffect;
    public float Cash_Amount;
    public static event Action<float> OnEnemyKilled; 


    void Start()
    {
        _enemy = new Enemy(health, Cash_Amount); 
    }

    public Enemy EnemyInstance {

        get { return _enemy; }
    }
    
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
            // StoreManager manager = FindObjectOfType<StoreManager>();
            // manager.playerMoney += (_enemy.cash_amount);
        }

    }

    void die()
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        if (OnEnemyKilled != null) // Add this if statement
        {
            OnEnemyKilled(_enemy.cash_amount);
        }
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


public class Enemy
{
    public float health;
    public float cash_amount;

    public Enemy(float HP, float Cash_Amount)
    {
        health = HP;
        cash_amount = Cash_Amount; // corrected assignment
    }

    public void CashAmount() {

        cash_amount = 10f; 
    }
}