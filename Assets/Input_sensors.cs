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
        else if(n == 4)
        {
            return distanceFromDown();
        }
        else if (n == 5)
        {
            return distanceFromTop();
        }
        else if (n == 6)
        {
            return distanceFromRight();
        }
        else if (n == 7)
        {
            return distanceFromLeft();
        }
        return 0;
    }
	public double downFromOrganism()
	{
		int y = loc.y;
		int distance = Globals.WORLD_SIZE;
		for (int i = y+1; i< Globals.WORLD_SIZE; i++)
		{
			if (Globals.world[loc.x, i] != 0)
			{
				distance = i - y;
				break;
			}
		}
		return (Globals.WORLD_SIZE - distance)/Globals.WORLD_SIZE;
	}
    public double upFromOrganism()
    {
        int y = loc.y;
        int distance = Globals.WORLD_SIZE;
        for (int i = y - 1; i >= 0; i--)
        {
            if (Globals.world[loc.x, i] != 0)
            {
                distance = y - i;
                break;
            }
        }
        return (Globals.WORLD_SIZE - distance) / Globals.WORLD_SIZE;
    }
    public double rightFromOrganism()
    {
        int x = loc.x;
        int distance = Globals.WORLD_SIZE;
        for (int i = x + 1; i < Globals.WORLD_SIZE; i++)
        {
            if (Globals.world[i, loc.y] != 0)
            {
                distance = i - x;
                break;
            }
        }
        return (Globals.WORLD_SIZE - distance) / Globals.WORLD_SIZE;
    }
    public double leftFromOrganism()
    {
        int x = loc.x;
        int distance = Globals.WORLD_SIZE;
        for (int i = x - 1 ; i >= 0; i--)
        {
            if (Globals.world[i, loc.y] != 0)
            {
                distance = x - i;
                break;
            }
        }
        return (Globals.WORLD_SIZE - distance) / Globals.WORLD_SIZE;
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
