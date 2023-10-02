
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    Cell[,] cells;
    float cellSize = 0.25f; //Size of our cells
    int numberOfColums, numberOfRows;
    int spawnChancePercentage = 15;
    int neighboursAlive = 0;

    List<Cell> aliveCells = new List<Cell>();
    List<Cell> deadCells = new List<Cell>();
    void Start()
    {
        //Lower framerate makes it easier to test and see whats happening.
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 4;

        //Calculate our grid depending on size and cellSize
        numberOfColums = (int)Mathf.Floor((Camera.main.orthographicSize *
            Camera.main.aspect * 2) / cellSize);
        numberOfRows = (int)Mathf.Floor(Camera.main.orthographicSize * 2 / cellSize);

        //Initiate our matrix array
        cells = new Cell[numberOfColums, numberOfRows];

        //Create all objects

        //For each row
        for (int y = 0; y < numberOfRows; y++)
        {
            //for each column in each row
            for (int x = 0; x < numberOfColums; x++)
            {
                //Create our game cell objects, multiply by cellSize for correct world placement
                Vector2 newPos = new Vector2(x * cellSize - Camera.main.orthographicSize *
                    Camera.main.aspect,
                    y * cellSize - Camera.main.orthographicSize);

                var newCell = Instantiate(cellPrefab, newPos, Quaternion.identity);
                newCell.transform.localScale = Vector2.one * cellSize;
                cells[x, y] = newCell.GetComponent<Cell>();

                //Random check to see if it should be alive
                if (Random.Range(0, 100) < spawnChancePercentage)
                {
                    cells[x, y].alive = true;
                }

                cells[x, y].UpdateStatus();

            }

        }
    }
    void Update()
    {
        //TODO: Calculate next generation

        UpdateBuffer();

        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {

                GetNeighbours(x, y);
                cells[x, y].UpdateStatus();
            }
        }

    }

    private void UpdateBuffer()
    {
        foreach (var cell in deadCells)
        {
            cell.alive = false;

        }
        foreach (var cell in aliveCells)
        {
            cell.alive = true;
        }
        deadCells.Clear();
        aliveCells.Clear();
    }

    public void GetNeighbours(int x, int y)
    {
        int startY = Mathf.Max(0, y - 1);
        int maxY = Mathf.Min(numberOfRows, y + 2);

        int startX = Mathf.Max(0, x - 1);
        int maxX = Mathf.Min(numberOfColums, x + 2);

        for (int a = startY; a < maxY; a++)
        {
            for (int b = startX; b < maxX; b++)
            {
                if (!(a == y && b == x))
                {
                    if (cells[b, a].alive)
                    {
                        neighboursAlive++;
                    }
                }
            }
        }
        CheckifCellisAlive(x, y);
    }

    private void CheckifCellisAlive(int x, int y)
    {
        if (cells[x, y].alive && neighboursAlive == 2 || cells[x, y].alive && neighboursAlive == 3)
        {

        }
        if (!cells[x, y].alive && neighboursAlive == 3)
        {
            aliveCells.Add(cells[x, y]);
        }
        if (cells[x, y].alive && neighboursAlive < 2 || cells[x, y].alive && neighboursAlive > 3)
        {
            deadCells.Add(cells[x, y]);
        }
        neighboursAlive = 0;
    }

}
