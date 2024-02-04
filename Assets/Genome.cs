using JetBrains.Annotations;
using System;

public class Gene
{
	public String [] gene = new string[Globals.GeneLength];
	public String binaryGene = "";
	public Gene()
	{
		for (int i = 0; i < Globals.GeneLength; i++)
		{
			gene[i] = generateHexCode();
			binaryGene += Convert.ToString(Convert.ToInt32(gene[i], 16), 2);
		}
	}

	public String generateHexCode()
	{
		Random rand = new Random();
		int n = rand.Next(0, 16);
		return n.ToString("X");
	}

	public int getIntValue(int start, int length)
	{
		return Convert.ToInt32(binaryGene.Substring(start, length), 2);
	}

}

public class Genome
{
	public Gene [] genome = new Gene[Globals.GenomeLength];
	public Genome()
	{
		for (int i = 0;i < Globals.GenomeLength;i++)
		{
			genome[i] = new Gene();
		}
	}
}
