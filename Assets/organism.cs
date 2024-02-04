using System;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static int numberOfOrganisms = 1000;
    public static int numberOfInputSensors = 4;
    public static int numberOfOutputSensors = 4;
    public static int WORLD_SIZE = 128;
    public static int GenomeLength = 8;
    public static int GeneLength = 6;
    public static int[,] world = new int[WORLD_SIZE, WORLD_SIZE];
    public static List<Organism> organisms = new List<Organism>();
    public static List<GameObject> displayWorld = new List<GameObject>();
}
public class Organism
{
    public Cords loc;
    public Input_sensors input;
    public Output_sensors output;
    public Genome genome;
    public NeuralNet brain;

    public Organism()
    {
        loc = new Cords();
        Globals.world[loc.x, loc.y] = 1;

        input = new Input_sensors(this);
        output = new Output_sensors(this);
        brain = new NeuralNet(this);
    }
}
