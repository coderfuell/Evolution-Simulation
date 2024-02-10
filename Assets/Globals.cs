using System;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static int FrameRate = 100;
    public static int WORLD_SIZE = 128;
    public static double mutationProbablity = 1;
    public static int stepsPerGeneration = 100;
    public static int numberOfOrganisms = 1000;
    public static int numberOfInputSensors = 8;
    public static int numberOfOutputSensors = 4;
    public static int numberOfInternalNeurons = 2;
    public static int GenomeLength = 20;
    public static int GeneLength = 6;
    public static int[,] world = new int[WORLD_SIZE, WORLD_SIZE];
    public static List<Organism> organisms = new List<Organism>();

    public static int probabilityFunction(double probability)
    {
        System.Random rand = new System.Random();
        if (rand.NextDouble() < probability)
        {
            return 1;
        }
        return 0;
    }
    public static void setWorldtoZero()
    {
        for (int i = 0; i < Globals.WORLD_SIZE; i++)
            for (int j = 0; j < Globals.WORLD_SIZE; j++)
                Globals.world[i, j] = 0;
    }
}
