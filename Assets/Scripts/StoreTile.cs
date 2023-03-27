using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StoreTile : MonoBehaviour
{
    // create instance to store boxdata, easy to access it elsewhere
    // by using "StoreBoxData.instance"
    public static StoreTile instance;
    public Tilemap Tilemap;

    //create dictionary to store boxstatus tiles
    public Dictionary<Vector3, FloorStatus> tiles;

    //method called when "storeboxdata" is created
    private void Awake()
    {
        //checks and sets "instance" variable to object or 
        //destroy object if "instance" already exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        GetWorldTiles();
    }

    // Use this for initialization
    private void GetWorldTiles()
    {
        //populate dictionary
        tiles = new Dictionary<Vector3, FloorStatus>();
        //loop through each tile in tilemap
        foreach (Vector3Int pos in Tilemap.cellBounds.allPositionsWithin)
        //a property in unity that returns an iterator over all the positions
        //within tilemap
        {
            //position of tile
            var localPlace = new Vector3Int(pos.x, pos.y, pos.z);

            //check if position is empty
            if (!Tilemap.HasTile(localPlace)) continue;

            //create new boxstatus for each tile
            var tile = new FloorStatus
            {
                LocalPlace = localPlace,
                //set to world position
                WorldLocation = Tilemap.CellToWorld(localPlace),
                //tile(data type) set to localplace
                TileBase = Tilemap.GetTile(localPlace),
                TilemapMember = Tilemap,
                //string represent the position
                Name = localPlace.x + "," + localPlace.y,
                Cost = 1
            };
            // add worldlocation to tile -- make it easy to be accessed later
            tiles.Add(tile.WorldLocation, tile);
        }
    }
}