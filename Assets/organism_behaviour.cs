using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Organism_behaviour : MonoBehaviour
{
    public Camera cam;
    public GameObject prefab;
    int nextGen = 0;
    int genNumber = 0;

    void displayControl()
    {
        Application.targetFrameRate = Globals.FrameRate;
        transform.localScale = new Vector2(Globals.WORLD_SIZE, Globals.WORLD_SIZE);
        transform.localPosition = new Vector2((Globals.WORLD_SIZE - 1) / 2, (Globals.WORLD_SIZE - 1) / 2);
        cam.orthographicSize = Globals.WORLD_SIZE / 2;
        cam.transform.position = new Vector3((Globals.WORLD_SIZE - 1) / 2, (Globals.WORLD_SIZE - 1) / 2, -10);
    }
        
    // Start is called before the first frame update
    void Start()
    {
        displayControl();
        Globals.setWorldtoZero();
        DateTime currentTime = DateTime.Now;
        for (int i = 0; i < Globals.numberOfOrganisms; i++)
        {
            Organism organism = new Organism(prefab);
            Globals.organisms.Add(organism);
        }
        //StreamWriter writer = new StreamWriter("C:\\Users\\deepe\\Evolution Sim\\Geneticdata.txt");
    }

    // Update is called once per frame


    void Update()
    {
        for (int i = 0;i < Globals.numberOfOrganisms;i++)
        {
            Globals.organisms[i].brain.processOutput();
            (float x, float y) = (Globals.organisms[i].loc.x, Globals.WORLD_SIZE - Globals.organisms[i].loc.y - 1);
            Globals.organisms[i].prefab.transform.position = new Vector3(x, y, 0);
            Globals.organisms[i].genome.mutation();
        }
        nextGen++;
        if (nextGen > Globals.stepsPerGeneration)
        {
            Survival.GotoNextGen();
            nextGen = 0;
            genNumber++;
            Debug.Log(genNumber);
            if (genNumber % 5 == 0)
            {
                System.Random rand = new System.Random();
                string line;
                line = genNumber.ToString() + ", " + Globals.organisms[rand.Next(Globals.numberOfOrganisms)].genome.genomestring;
                //StreamWriter writer = new StreamWriter("C:\\Users\\deepe\\Evolution Sim\\Geneticdata.txt");
                //while (!string.IsNullOrWhiteSpace(line))
                //{
                //writer.WriteLine(line);
                //}
                Debug.Log(line);
            }
        }
    }

}

