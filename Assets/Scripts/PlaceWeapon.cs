using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;


public class PlaceWeapon : MonoBehaviour
{
    private FloorStatus floorStatus;
    private StoreManager storeManager;

    public GameObject LaserGun;

    private void Start()
    {
        storeManager = FindObjectOfType<StoreManager>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && storeManager.ButtonDown == true)
        {
            //print("2");
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var worldPoint = new Vector3Int(Mathf.FloorToInt(point.x), Mathf.FloorToInt(point.y), 0);
            var spawnPoint = new Vector3(Mathf.FloorToInt(point.x) + (float)0.5, Mathf.FloorToInt(point.y) + (float)0.5, 0);

            var tiles = StoreTile.instance.tiles; // This is our Dictionary of tiles

            if (tiles.TryGetValue(worldPoint, out floorStatus) && tiles != null)
            {
                //print("3");
                storeManager.ButtonDown = false;       
                floorStatus.TilemapMember.SetTileFlags(floorStatus.LocalPlace, TileFlags.None);
                print(worldPoint);

                if (worldPoint.y >= 3)
                {
                     Instantiate (LaserGun, spawnPoint, Quaternion.Euler(0, 0, 180));
                }

                else
                {
                    Instantiate(LaserGun, spawnPoint, transform.rotation);

                }
                   
            }
            
        }
    }

}