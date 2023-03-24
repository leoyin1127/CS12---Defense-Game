using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualWeapon : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform FirePoint;
    public GameObject BulletPrefab;
     

    void Start()
    {
        
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

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
