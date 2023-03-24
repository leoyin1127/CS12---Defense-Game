using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    private float clock;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;  
    }

    private void Update()
    {
        if (transform.position.y > 3.82f)
        {
            transform.position = new Vector3(transform.position.x, 3.82f, -12);
        }
        if (transform.position.y < -3.82f)
        {
            transform.position = new Vector3(transform.position.x, -3.82f, -12);
        }
        clock += 1f * Time.deltaTime;
        Timer();
    }

    private void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name); 
        Destroy(gameObject); 
    }

    void Timer()
    {
        if (clock >= 5)
        {
            Destroy(gameObject); 
        }

    }
}
