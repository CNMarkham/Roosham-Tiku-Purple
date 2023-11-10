using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float speed;
    private float previousTime;
    public float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 10;
    public Vector3 rotationPoint;
    public static Transform[,] grid = new Transform[width, height];
    public void AddToGrid()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);
            grid[x, y] = child;
        }
    }
    public bool ValidMove()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);
            if (x < 0 || y < 0 )
            {
                return false;
            }

            if (x >= width || y >= height)
            {
                return false;
            }
            if (grid[x,y] != null)
            {
                return false;
            }
        }
        return true;
    }

    void CheckLines()
    {
        for(int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }
    bool HasLine(int i)
    {
        for(int j=0; j < width; j++)
        {
            if(grid[j,i] == null)
            {
                return false;
            }
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j< width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if(grid[x,y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].transform.position += Vector3.down;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 convertedPoint = transform.TransformPoint(rotationPoint);
            transform.RotateAround(convertedPoint, Vector3.forward, 90);
            if (!ValidMove())
            {
                transform.RotateAround(convertedPoint, Vector3.forward, -90);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left, Space.World);
            if (!ValidMove())
            {
                transform.Translate(Vector3.right, Space.World);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right, Space.World);
            if (!ValidMove())
            {
                transform.Translate(Vector3.left, Space.World);
            }
        }

        float tempTime = fallTime;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            tempTime = tempTime / 10;
        }

        if (Time.time - previousTime > tempTime)
        {
            transform.Translate(Vector3.down, Space.World);
            previousTime = Time.time;
            if (!ValidMove())
            {
               
                transform.Translate(Vector3.up, Space.World);
                AddToGrid();
                CheckLines();
                this.enabled = false;
                FindObjectOfType<Spawner>().SpawnTetromino();
            }
        }
       
        
    }
}
