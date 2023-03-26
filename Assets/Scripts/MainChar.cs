using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MainChar : MonoBehaviour
{
    private Ship _ship; 

    public float Move;
    public float MoveDown;

    // Start is called before the first frame update
    void Start()
    {
        _ship = new Ship(Move, MoveDown); 
        Move = 1f;
        MoveDown = -1f;
    }


    // Update is called once per frame  
    void Update()
    {
        if (transform.position.y > 3.82f)
        {
            transform.position = new Vector3(transform.position.x, 3.82f, -12);
        }
        if (transform.position.y < -3.82f)
        {
            transform.position = new Vector3(transform.position.x, -3.82f, -12);
        }

        if (Input.GetKey(KeyCode.S) == true)
        {
            _ship.MoveDown();
            transform.position += Vector3.up * _ship.movedown * Time.deltaTime*4;
        }
      
        if (Input.GetKey(KeyCode.W) == true)
        {
            _ship.MoveUp();
            transform.position += Vector3.up * _ship.move * Time.deltaTime*4;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) == false)
        {
            _ship.Still();
            transform.position += Vector3.up * _ship.move * Time.deltaTime*4;
        }

            
    }
}

public class Ship
{
    // Attributes
    public float move;
    public float movedown; 
   

    public Ship(float Move, float MoveDown)
    {
        move = Move;
        movedown = MoveDown;
    }
    public void MoveDown()
    {
        movedown = -1f;
    }

    public void MoveUp()
    {
        move = 1f;
    }
    public void Still()
    {
        move = 0f; 
    }

}

