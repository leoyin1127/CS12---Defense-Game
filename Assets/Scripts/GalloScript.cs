using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GalloScript : MonoBehaviour
{
    private Gallo _gallo; 

    public float Move;
    public float MoveDown; 
 
    

    // Start is called before the first frame update
    void Start()
    {
        _gallo = new Gallo(Move, MoveDown); 
        Move = 1;
        MoveDown = -1; 
    }


    // Update is called once per frame
    void Update()
    {
  
        if (Input.GetKey(KeyCode.S) == true)
        {
            _gallo.MoveDown();
            transform.position += Vector3.up * _gallo.movedown * Time.deltaTime*2;
        }

        if (Input.GetKey(KeyCode.W) == true)
        {
            _gallo.MoveUp();
            transform.position += Vector3.up * _gallo.move * Time.deltaTime*2;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) == false)
        {
            _gallo.Still();
            transform.position += Vector3.up * _gallo.move * Time.deltaTime*2;
        }

            
    }
}

public class Gallo
{
    // Attributes
    public float move;
    public float movedown; 
   

    public Gallo(float Move, float MoveDown)
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
        move = 1;
    }
    public void Still()
    {
        move = 0; 
    }

}

