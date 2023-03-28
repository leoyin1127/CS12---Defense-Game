using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class PlaceWeapon : MonoBehaviour
{
    private FloorStatus floorStatus;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var worldPoint = new Vector3Int(Mathf.FloorToInt(point.x), Mathf.FloorToInt(point.y), 0);

            var tiles = StoreTile.instance.tiles; // This is our Dictionary of tiles

            if (tiles.TryGetValue(worldPoint, out floorStatus))
            {
                print("Tile " + floorStatus.Name + " costs: " + floorStatus.Cost);
                floorStatus.TilemapMember.SetTileFlags(floorStatus.LocalPlace, TileFlags.None);
                floorStatus.TilemapMember.SetColor(floorStatus.LocalPlace, Color.green);
            }
        }
    }
}