using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualWeapon : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform FirePoint;
    public GameObject BulletPrefab;
    public float timer;
    public float cooldown; 
    
    private WeaponController weaponController;

    void Start()
    {
        timer = 0f;
        cooldown = 0.4f;
        weaponController = FindObjectOfType<WeaponController>();
    }

    // Update is called once per frame
    void Update()
    {

        // Cooldown 
        Clock();

        // Boundary 
        if (transform.position.y > 3.82f)
        {
            transform.position = new Vector3(transform.position.x, 3.82f, -10);
        }
        if (transform.position.y < -3.82f)
        {
            transform.position = new Vector3(transform.position.x, -3.82f, -10);
        }


        // Fire Bullet
        if (Input.GetButton("Fire1") && timer >= cooldown)
        {
            Shoot();
            timer = 0f; 
        }
    }


    // Bullet Function 
    void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);

        // Initialize the bullet with the damage value from the WeaponController
        BulletScript bulletScript = newBullet.GetComponent<BulletScript>();
        bulletScript.InitializeBullet(weaponController.damage);
    }

    void Clock()
    {
        timer += 1 * Time.deltaTime; 
    }
}
