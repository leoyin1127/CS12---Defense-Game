using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    private void Start()
    {
<<<<<<< HEAD
        grid = new Grid(7, 5, 2f, new Vector3(-5, 0));

    }

  
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(Mathf.FloorToInt(GetMouseWorldPosition().x), Mathf.FloorToInt(GetMouseWorldPosition().y), 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(GetMouseWorldPosition()));
        }
    }

    // Get Mouse Position in World with Z = 0f
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

=======
        Grid grid = new Grid(5, 5);
    }
>>>>>>> parent of e6662f0 (Merge)
}
