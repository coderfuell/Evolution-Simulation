using System;
using Unity.Collections;
using UnityEditor.UI;

public class Input_sensors
{
    Organism org;
    Cords loc;
    public Input_sensors(Organism org) {
        this.org = org;
        this.loc = org.loc;
    }
    public double callInput(int n)
    {
        n = n % Globals.numberOfInputSensors;
        if (n == 0)
        { return downFromOrganism(); }
        else if (n == 1)
        {
            return upFromOrganism();
        }
        else if (n == 2)
        {
            return rightFromOrganism();
        }
        else if (n == 3)
        {
            return leftFromOrganism();
        }
        return 0;
    }
	public double downFromOrganism()
	{
		int y = loc.y;
		int distance = 0;
		double output = Globals.WORLD_SIZE;
		for (int i = y+1; i< Globals.WORLD_SIZE; i++)
		{
			if (Globals.world[loc.x, i] != null)
			{
				distance = i - y;
				break;
			}
		}
		if (distance == 0) { return 0.0; }
		return (output - distance)/Globals.WORLD_SIZE;
	}
    public double upFromOrganism()
    {
        int y = loc.y;
        int distance = 0;
        double output = Globals.WORLD_SIZE;
        for (int i = y - 1; i >= 0; i--)
        {
            if (Globals.world[loc.x, i] != null)
            {
                distance = y - i;
                break;
            }
        }
        if (distance == 0) { return 0.0; }
        return (output - distance) / Globals.WORLD_SIZE;
    }
    public double rightFromOrganism()
    {
        int x = loc.x;
        int distance = 0;
        double output = Globals.WORLD_SIZE;
        for (int i = x + 1; i < Globals.WORLD_SIZE; i++)
        {
            if (Globals.world[i, loc.y] != null)
            {
                distance = i - x;
                break;
            }
        }
        if (distance == 0) { return 0.0; }
        return (output - distance) / Globals.WORLD_SIZE;
    }
    public double leftFromOrganism()
    {
        int x = loc.x;
        int distance = 0;
        double output = Globals.WORLD_SIZE;
        for (int i = x - 1 ; i >= 0; i--)
        {
            if (Globals.world[i, loc.y] != null)
            {
                distance = x - i;
                break;
            }
        }
        if (distance == 0) { return 0.0; }
        return (output - distance) / Globals.WORLD_SIZE;
    }
    public double distanceFromLeft()
    {
        return ((double)loc.x)/Globals.WORLD_SIZE;
    }
    public double distanceFromRight()
    {
        return ((double)Globals.WORLD_SIZE) - (double)loc.x/Globals.WORLD_SIZE;
    }
    public double distanceFromTop()
    {
        return ((double)loc.y)/Globals.WORLD_SIZE;
    }
    public double distanceFromDown()
    {
        return ((double)Globals.WORLD_SIZE - (double)loc.y) / Globals.WORLD_SIZE;
    }


}
