using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism_behaviour : MonoBehaviour
{
    public Camera cam;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 20;
        transform.localScale = new Vector2(Globals.WORLD_SIZE, Globals.WORLD_SIZE);
        transform.localPosition = new Vector2((Globals.WORLD_SIZE - 1) / 2, (Globals.WORLD_SIZE - 1) / 2);
        cam.orthographicSize = Globals.WORLD_SIZE / 2;
        cam.transform.position = new Vector3((Globals.WORLD_SIZE - 1) / 2, (Globals.WORLD_SIZE - 1) / 2, -10);
        for (int i = 0; i < Globals.numberOfOrganisms; i++)
        {
            Organism organism = new Organism();
            Globals.organisms.Add(organism);
        }
        for (int i = 0; i < Globals.WORLD_SIZE; i++)
            for (int j = 0; j < Globals.WORLD_SIZE; j++)
                Globals.world[i, j] = 0;

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0;i < Globals.numberOfOrganisms;i++)
        {
            (float x, float y) = (Globals.organisms[i].loc.x ,Globals.WORLD_SIZE - Globals.organisms[i].loc.y - 1);
            Globals.displayWorld.Add(Instantiate(prefab, new Vector2(x, y), Quaternion.identity));

            Globals.organisms[i].brain.callOutputNeuron();
            Destroy(Globals.displayWorld[i], Time.deltaTime*3);
        }
        Globals.displayWorld.Clear();
    }
}
