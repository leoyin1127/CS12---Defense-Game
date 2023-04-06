using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 2f;
    public Rigidbody2D rb;
    private float clock;
    public float damage = 40;
    public GameObject impactEffect;
    private Turret turret;

    // Start is called before the first frame update
    void Start()
    {
        turret = GetComponentInParent<Turret>();

        if (turret != null)
        {
            Vector3 velocity = new Vector3(speed * turret.direction.x, speed * turret.direction.y, speed * turret.direction.z);
            rb.velocity = velocity;
            Debug.Log(turret.direction + "CCCCCCCCCCCCCCCCCCCCCCCCCCCCC");
        }
        else
        {
            rb.velocity = transform.right * speed;
        }
    }

    private void Update()
    {
        clock += 1f * Time.deltaTime;
        Timer();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        EnemyValues enemy = hitInfo.GetComponent<EnemyValues>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void Timer()
    {
        if (clock >= 5)
        {
            Destroy(gameObject);
        }
    }

    // Initialize bullet damage
    public void InitializeBullet(float damageValue)
    {
        damage = damageValue;
    }
}