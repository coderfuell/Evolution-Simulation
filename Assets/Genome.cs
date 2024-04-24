using System;
using System.Diagnostics;
using UnityEngine;
public class Gene
{
	public String gene = "";
	public String binaryGene = "";
	public Gene()
	{
		for (int i = 0; i < Globals.GeneLength; i++)
		{
			String singleHex = generateHexCode();
			gene += singleHex;
			binaryGene += Convert.ToString(Convert.ToInt32(singleHex, 16), 2).PadLeft(4, '0');
		}
	}

	public String generateHexCode()
	{
		System.Random rand = new System.Random();
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
	public Gene [] geneList = new Gene[Globals.GenomeLength];
	public string genomestring = "";
	public Genome()
	{
		for (int i = 0;i < Globals.GenomeLength;i++)
		{
			geneList[i] = new Gene();
			genomestring += geneList[i].gene;
		}
	}

	public void mutation()
	{
		System.Random rand = new System.Random();
		int geneIndex = rand.Next(geneList.Length);
		int bitIndex = rand.Next(Globals.GeneLength * 4);

		String n = geneList[geneIndex].binaryGene.Substring(bitIndex, 1);
		if (n == "1")
		{
			n = "0";
		}
		else
		{
			n = "1";
		}
        geneList[geneIndex].binaryGene.Remove(bitIndex, 1);
        geneList[geneIndex].binaryGene.Insert(bitIndex, "0");
    }

}
