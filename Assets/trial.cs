using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class Cell
{
    public int i;
    public int j;
    public GameObject gObject;
    public int worldSize;
    SpriteRenderer spriteRenderer;
    public Cell(GameObject gObject, int worldSize)
    {
        this.gObject = gObject;
        this.worldSize = worldSize;
        gObject.GetComponent<SpriteRenderer>().color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1.0f);


    }

    public bool moveUp(ref Cell[,] world)
    {
        if (gObject.transform.position.y + 1 < worldSize)
        {
            (i, j) = ((int)gObject.transform.position.y, (int)gObject.transform.position.x);
            if (world[i + 1, j] == null)
            {
                (world[i + 1, j], world[i, j]) = (world[i, j], world[i + 1, j]);
                gObject.transform.position += new Vector3(0, 1, 0);
                return true;
            }
        }
        return false;
    }

    public bool moveDown(ref Cell[,] world)
    {
        if (gObject.transform.position.y > 0)
        {
            (i, j) = ((int)gObject.transform.position.y, (int)gObject.transform.position.x);
            if (world[i - 1, j] == null)
            {
                (world[i - 1, j], world[i, j]) = (world[i, j], world[i - 1, j]);
                gObject.transform.position -= new Vector3(0, 1, 0);
                return true;
            }
        }
        return false;
    }
    public bool moveRight(ref Cell[,] world)
    {
        if (gObject.transform.position.x + 1 < worldSize)
        {
            (i, j) = ((int)gObject.transform.position.y, (int)gObject.transform.position.x);
            if (world[i, j + 1] == null)
            {
                (world[i, j + 1], world[i, j]) = (world[i, j], world[i, j + 1]);
                gObject.transform.position += new Vector3(1, 0, 0);
                return true;
            }
        }
        return false;
    }

    public bool moveLeft(ref Cell[,] world)
    {
        if (gObject.transform.position.x > 0)
        {
            (i, j) = ((int)gObject.transform.position.y, (int)gObject.transform.position.x);
            if (world[i, j - 1] == null)
            {
                (world[i, j - 1], world[i, j]) = (world[i, j], world[i, j - 1]);
                gObject.transform.position -= new Vector3(1, 0, 0);
                return true;
            }
        }
        return false;
    }

    public bool moveRandom(ref Cell[,] world, int ran)
    {
        if (ran == 0)
        {
            ran = UnityEngine.Random.Range(0, 4);
        }
        ran = ran % 4;
        switch (ran)
        {
            case 0:
                return moveUp(ref world);
            case 1:
                return moveDown(ref world);
            case 2:
                return moveLeft(ref world);
            case 3:
                return moveRight(ref world);
            default:
                return false;
        }
    }
}