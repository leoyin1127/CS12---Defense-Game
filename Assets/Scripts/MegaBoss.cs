using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MegaBoss : MonoBehaviour
{
    public float Move = 0f;
    public float speed = 0f;
    public float MoveDown = 0f, MoveUp = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        // Initial Dodge Speed
        Move = 0.8f;
        MoveUp = 0.8f;
        MoveDown = -0.8f; 
    }

    // Update is called once per frame
    void Update()
    {
        speed += 0.1f * Time.deltaTime; 
        Dodge();
        Movement();
    }

    void Dodge()
    {
        transform.position += Vector3.up * Move * Time.deltaTime *2;

        // DodgeDown
        if (transform.position.y > 3.75f)
        {
            MoveDown -= 0.3f; 
            Move = MoveDown;
        }

        // DodgeUp
        if (transform.position.y < -3.75f)
        {
            MoveUp += 0.3f;
            Move = MoveUp;
        }

        //Max Dodge
        if (MoveUp >= 4f && MoveDown <= -4f)
        {
            MoveUp = 4f;
            MoveDown = -4f;
        }
    }

    void Movement()
    {
        transform.position += Vector3.right * speed * Time.deltaTime / 3;
        if (speed >= 3f)
        {
            speed = 3f; 
        }

    }
}

