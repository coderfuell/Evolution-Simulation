using System;
using Unity.VisualScripting;

public class Output_sensors
{
    Organism organism;
    Cords loc;
	public Output_sensors(Organism org)
	{
        organism = org;
        this.loc = org.loc;
    }

    public int callOutput(int n)
    {
        n = n % Globals.numberOfOutputSensors;
        if (n == 0)
        { return moveUp(); }
        else if (n == 1)
        {
            return moveDown();
        }
        else if (n == 2)
        {
            return moveRight();
        }
        else if (n == 3)
        {
            return moveLeft();
        }
        return 0;
    }
    public int moveLeft()
	{
        if (loc.x - 1 >= 0)
        {
            if (Globals.world[loc.x - 1, loc.y] == 0)
            {
                Globals.world[loc.x - 1, loc.y] = 1;
                Globals.world[loc.x, loc.y] = 0;
                loc.x -= 1;
                return 1;
            }
        }
		return 0;
	}

    public int moveRight()
    {
        if (loc.x + 1 < Globals.WORLD_SIZE)
        {
            if (Globals.world[loc.x + 1, loc.y] == 0)
            {
                Globals.world[loc.x + 1, loc.y] = 1;
                Globals.world[loc.x, loc.y] = 0;
                loc.x += 1;

                return 1;
            }
        }
        return 0;
    }

    public int moveUp()
    {
        if (loc.y - 1 >= 0)
        {
            if (Globals.world[loc.x, loc.y - 1] == 0)
            {
                Globals.world[loc.x, loc.y - 1] = 1;
                Globals.world[loc.x, loc.y] = 0;

                loc.y -= 1;
                return 1;
            }
        }
        return 0;
    }

    public int moveDown()
    {
        if (loc.y + 1 < Globals.WORLD_SIZE)
        {
            if (Globals.world[loc.x , loc.y +1] == 0)
            {
                Globals.world[loc.x, loc.y + 1] = 1;
                Globals.world[loc.x, loc.y] = 0;

                loc.y += 1;
                return 1;
            }
        }
        return 0;
    }
}
