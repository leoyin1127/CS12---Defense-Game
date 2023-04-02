using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedyInvaderMovement : MonoBehaviour
{
    public float Move;
    public float Position;
    public float clock;
    public float clock_value;
    public float speed = 2;
    public static bool allowmove = true;
    // Start is called before the first frame update
    void Start()
    {
        Move = 1;
        clock_value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (allowmove == true)
        {
            clock += clock_value * Time.deltaTime;
            Bobbing();
            Movement();
        }
    }

    public void Bobbing()
    {
        if (clock >= 3f)
        {
            Move = -1f;
            clock_value = -1;
        }
        if (clock <= 0)
        {
            Move = 1;
            clock_value = 1;
        }
        transform.position += Vector3.up * Move * Time.deltaTime / 5;
    }

    public void Movement()
    {

        transform.position += Vector3.right * speed * Time.deltaTime / 3;
    }

}
