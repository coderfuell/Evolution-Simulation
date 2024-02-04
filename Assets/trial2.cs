using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    public static float worldSize = 64;
    public GameObject prefab;
    public System.Random rand = new System.Random();
    public Camera cam;
    public int dir = 0;
    private Cell[,] world;
    private Cell[,] future;

    bool spawnByProbability(int probability)
    {
        if (probability > rand.Next(101))
        {
            return true;
        }
        return false;
    }


    void Start()
    {
        Application.targetFrameRate = 240;
        world = new Cell[(int)worldSize, (int)worldSize];
        transform.localScale = new Vector2(worldSize, worldSize);
        transform.localPosition = new Vector2((worldSize - 1) / 2, (worldSize - 1) / 2);
        cam.orthographicSize = worldSize / 2;
        cam.transform.position = new Vector3((worldSize - 1) / 2, (worldSize - 1) / 2, -10);



        for (int i = 0; i < worldSize; i++)
        {
            for (int j = 0; j < worldSize; j++)
            {
                if (spawnByProbability(20))
                {
                    world[i, j] = new Cell(Instantiate(prefab, new Vector2(j, i), Quaternion.identity), (int)worldSize);
                }
            }
        }
    }
    static int[,] GenerateAndShufflePairs(int n)
    {
        var pairs = from i in Enumerable.Range(0, n)
                    from j in Enumerable.Range(0, n)
                    select new { First = i, Second = j };

        var shuffledPairs = pairs.OrderBy(_ => Guid.NewGuid()).ToArray();

        int[,] result = new int[shuffledPairs.Length, 2];
        for (int i = 0; i < shuffledPairs.Length; i++)
        {
            result[i, 0] = shuffledPairs[i].First;
            result[i, 1] = shuffledPairs[i].Second;
        }

        return result;
    }


    void Update()
    {
        int[,] coords = GenerateAndShufflePairs((int)worldSize);
        for (int a = 0; a < worldSize * worldSize; a++)
        {
            int i = coords[a, 0];
            int j = coords[a, 1];


            if (world[i, j] != null)
            {
                System.Console.WriteLine(world[i, j].moveRandom(ref world, dir));
            }
        }
    }

}
