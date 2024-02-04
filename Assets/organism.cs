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

    public Organism()
    {
        loc = new Cords();
        Globals.world[loc.x, loc.y] = 1;

        input = new Input_sensors(this);
        output = new Output_sensors(this);
        brain = new NeuralNet(this);
    }
}
