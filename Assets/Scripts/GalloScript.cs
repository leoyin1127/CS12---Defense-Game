using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GalloScript : MonoBehaviour
{

    public float Move;
    public float Position;
    public float clock;
    public float clock_value; 
     

    // Start is called before the first frame update
    void Start()
    {
        Move = 1;
        clock_value = 1;
    }


    // Update is called once per frame
    void Update()
    {
        clock += clock_value * Time.deltaTime;
        Movement();
    }


    public void Movement()
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
}



