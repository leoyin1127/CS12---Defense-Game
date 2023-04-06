using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AutomatedWeapon : MonoBehaviour
{

    public Transform firepoint;
    public GameObject ImpactEffect;
    public int damage = 40;
    public LineRenderer lineRenderer;


    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {

        RaycastHit2D hitinfo = Physics2D.Raycast(firepoint.position, firepoint.right);

        if (hitinfo)
        {
            EnemyValues enemy = hitinfo.transform.GetComponent<EnemyValues>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(ImpactEffect, hitinfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, firepoint.position);
            lineRenderer.SetPosition(1, hitinfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firepoint.position);
            lineRenderer.SetPosition(1, firepoint.position + firepoint.up * 100);
        }

        lineRenderer.enabled = true;

        yield return 0; 

        lineRenderer.enabled = false;
    }
}
