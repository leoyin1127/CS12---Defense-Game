using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private Vector3 originPosition;
    //multi-dimensional array
    private int[,] gridArray;

    public int GetHeight()
    {
        return height;
    }

<<<<<<< HEAD
    public int GetWidth()
    {
        return width;
    }


    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
=======
    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;
>>>>>>> parent of e6662f0 (Merge)

        gridArray = new int[width, height];

        //figure out size of each dimension by cycling
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.Log(x + ", " + y);
            }

<<<<<<< HEAD
        UnityEngine.Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        UnityEngine.Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

        SetValue(2, 1, 10);

    }
    // Create Text in the World
    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        //int xPos = x - 4;
        //int yPos = y - 2;
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x - originPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y - originPosition.y / cellSize);

    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height && debugTextArray[x, y] != null)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
        else
        {
            UnityEngine.Debug.LogError("debugTextArray is null");
=======
>>>>>>> parent of e6662f0 (Merge)
        }
    }

}
