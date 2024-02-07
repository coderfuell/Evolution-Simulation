using System;

public class Cords
{
	public int x;
	public int y;
	public Cords()
	{
		Random rand = new Random();
		//Runs infinitely until a free space is found
		while (true)
		{
			//gets two random integer values from 0 to worldSize - 1
			x = rand.Next(0, Globals.WORLD_SIZE);
			y = rand.Next(0, Globals.WORLD_SIZE);
			
			//If the space is null in the world matrix at the location of a & b,
			//the loc is set to the a, b values.
			if (Globals.world[x, y] == 0)
            {
                Globals.world[x, y] = 1;
                break;
            }
		}
       
	}
}
