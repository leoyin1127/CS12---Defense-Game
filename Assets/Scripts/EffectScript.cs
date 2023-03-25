using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    public float clock; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock += 1f * Time.deltaTime;
        Timer();
    }

    void Timer()
    {
        if (clock >= 0.4f)
        {
            Destroy(gameObject); 
        }
    } 

}
