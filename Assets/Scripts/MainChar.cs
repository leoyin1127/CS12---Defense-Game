using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MainChar : MonoBehaviour
{
    private Ship _ship;

    // Start is called before the first frame update
    void Start()
    {
        _ship = new Ship(1f, -1f);
    }

    public Ship ShipInstance
    {
        get { return _ship; }
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
            transform.position += Vector3.up * _ship.MovingDown * Time.deltaTime * _ship.Speed;
        }

        if (Input.GetKey(KeyCode.W) == true)
        {
            _ship.MoveUp();
            transform.position += Vector3.up * _ship.Move * Time.deltaTime * _ship.Speed;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) == false)
        {
            _ship.Still();
            transform.position += Vector3.up * _ship.Move * Time.deltaTime * 4;
        }


    }
}

public class Ship
{
    // Attributes
    private float _move;
    private float _movedown;
    private float _speed = 4f;

    public Ship(float Move, float MoveDown)
    {
        _move = Move;
        _movedown = MoveDown;
    }
    public void MoveDown()
    {
        _movedown = -1f;
    }

    public void MoveUp()
    {
        _move = 1f;
    }
    public void Still()
    {
        _move = 0f;
    }


    // Getters and Setters
    public float Move
    {
        get { return _move; }
        set { _move = value; }
    }
    public float MovingDown
    {
        get { return _movedown; }
        set { _movedown = value; }
    }
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

}
