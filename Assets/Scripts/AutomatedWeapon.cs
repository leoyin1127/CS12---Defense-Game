using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject turret;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float shootingFrequency = 3f;
    [SerializeField]
    private int shootingRadius = 8;
    public Vector3 direction;

    private float angle;

    void Start()
    {
        StartCoroutine(turretShooter(turret, bullet));
    }

    IEnumerator turretShooter(GameObject turret, GameObject bullet)
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingFrequency);

            Collider2D[] colliders = Physics2D.OverlapCircleAll((turret.transform.position), shootingRadius);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.tag == "Ennemy")
                {
                    Debug.Log("ennemy found");
                    rotationAnimation(turret, colliders[i].gameObject);
                    GameObject childbullet = Instantiate(bullet, turret.transform.position, Quaternion.identity);
                    childbullet.transform.parent = turret.transform;
                    break;
                }
            }

        }
    }

    private void rotationAnimation(GameObject turret, GameObject ennemy)
    {
        turret.transform.rotation = Quaternion.Euler(0, 0, 0);
        direction = turret.transform.position - ennemy.transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Debug.Log(angle);
        turret.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
