using System;
using System.Collections.Generic;
using Unity.VisualScripting;

/*
public class NeuralNet
{
	Organism organism;
	Random rand;
	int n;
	public NeuralNet(Organism org)
	{
		this.organism = org;
		rand = new Random();
		n = rand.Next();
	}

	public int callInputNeuron()
	{
		organism.input.callInput(n);
		return 0;
	}

	public int callOutputNeuron()
	{
		organism.output.callOutput(rand.Next());
		return 0;
	}
}
*/

public class InternalNeuron
{
	public int numberOfInputs = 0;
	public int numberOfOutputs = 0;

	public List<double> inputs = new List<double>();
	public List<double> outputs = new List<double>();

	public double giveOutput()
	{
		return 0;
	}
}

public class NeuralNet
{
	Organism org;
	List<InternalNeuron> internalNeurons = new List<InternalNeuron>();

	public NeuralNet(Organism org)
	{
		this.org = org;
		org.color = org.genome.geneList[0].gene;
	}

	public void processGene(Gene gene)
	{
		int sourceType = gene.getIntValue(0, 1);
		int sourceID = gene.getIntValue(1, 5);

		int sinkType = gene.getIntValue(6, 1);
		int sinkID = gene.getIntValue(7, 5);

		if (sinkType == 1)
		{
			if (sourceType == 0)
			{
				internalNeurons[sinkID % Globals.numberOfInternalNeurons].inputs.Add(org.input.callInput(sourceID));
                internalNeurons[sinkID % Globals.numberOfInternalNeurons].numberOfInputs++;
            }
			else if (sourceType == 1) {
                internalNeurons[sinkID % Globals.numberOfInternalNeurons].inputs.Add(
					internalNeurons[sourceID % Globals.numberOfInternalNeurons].giveOutput());
                internalNeurons[sinkID % Globals.numberOfInternalNeurons].numberOfInputs++;
            }
		}
	}

}
