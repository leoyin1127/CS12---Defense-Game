using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyValues : MonoBehaviour
{

    private Enemy _enemy; 


    public float health;
    public GameObject DeathEffect;
    public float Cash_Amount;



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
            StoreManager manager = FindObjectOfType<StoreManager>();
            manager.playerMoney += (_enemy.cash_amount);
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


public class Enemy
{
    public float health;
    public float cash_amount;

    public Enemy(float HP, float Cash_Amount)
    {
        health = HP;
        Cash_Amount = cash_amount;
    }
    public void CashAmount() {

        cash_amount = 10; 
    }
}