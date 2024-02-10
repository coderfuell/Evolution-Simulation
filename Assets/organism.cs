using System;
using System.Collections.Generic;
using UnityEngine;
public class Organism
{
    public Cords loc;
    public Input_sensors input;
    public Output_sensors output;
    public Genome genome;
    public NeuralNet brain;
    public String color;
    public GameObject prefab;

    public Organism(GameObject prefab)
    {

        loc = new Cords();

        input = new Input_sensors(this);
        output = new Output_sensors(this);
        genome = new Genome();
        brain = new NeuralNet(this);

        (float x, float y) = (loc.x, Globals.WORLD_SIZE - loc.y - 1);
        this.prefab = UnityEngine.Object.Instantiate(prefab, new Vector2(x, y), Quaternion.identity);
        this.prefab.transform.position = new Vector3(x, y, 0);
        setColor();
    }

    public Organism(Organism org)
    {
        loc = new Cords();

        input = new Input_sensors(this);
        output = new Output_sensors(this);
        genome = org.genome;
        brain = new NeuralNet(this);
        (float x, float y) = (loc.x, Globals.WORLD_SIZE - loc.y - 1);
        this.prefab = UnityEngine.Object.Instantiate(org.prefab, new Vector2(x, y), Quaternion.identity);
        this.prefab.transform.position = new Vector3(x, y, 0);
        setColor();
    }

    public Organism getChild()
    {
        if (Globals.probabilityFunction(Globals.mutationProbablity) > 0)
        {
            this.genome.mutation();
        }
        Organism org = new Organism(this);
        return org;
    }

    void setColor()
    {
        SpriteRenderer sr = prefab.GetComponent<SpriteRenderer>();
        color = genome.geneList[0].gene;
        float r = (float)Convert.ToInt32(color.Substring(0, 2), 16) / 256;
        float g = (float)Convert.ToInt32(color.Substring(2, 2), 16) / 256;
        float b = (float)Convert.ToInt32(color.Substring(4, 2), 16) / 256;
        sr.color = new Color(r, g, b, 1);
    }
}
