﻿using System;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static int WORLD_SIZE = 128;
    public static int numberOfOrganisms = 1;
    public static int numberOfInputSensors = 8;
    public static int numberOfOutputSensors = 4;
    public static int numberOfInternalNeurons = 2;
    public static int GenomeLength = 8;
    public static int GeneLength = 6;
    public static int[,] world = new int[WORLD_SIZE, WORLD_SIZE];
    public static List<Organism> organisms = new List<Organism>();
    public static List<GameObject> displayWorld = new List<GameObject>();
}
