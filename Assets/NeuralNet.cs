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

	public List<double> inputs = new List<double>();

	public double giveOutput()
	{
		return 0;
	}
}

public class NeuralNet
{
	Organism org;

	InternalNeuron[] internalNeurons = new InternalNeuron[Globals.numberOfInternalNeurons];

	double[] outputs = new double[Globals.numberOfOutputSensors];


	public NeuralNet(Organism org)
	{
		this.org = org;
		org.color = org.genome.geneList[0].gene;
	}

	void createConnectionInput_InternalNeuron(int sourceID, int sinkID, double connectionWeight)
	{
		double connectionValue = org.input.callInput(sourceID) * connectionWeight;
		internalNeurons[sinkID % Globals.numberOfInternalNeurons].inputs.Add(connectionValue);
        internalNeurons[sinkID % Globals.numberOfInternalNeurons].numberOfInputs++;
    }

	void createConnectionInternalNeuron_InternalNeuron(int sourceID, int sinkID, double connectionWeight)
	{
		double connectionValue = internalNeurons[sourceID % Globals.numberOfInternalNeurons].giveOutput() * connectionWeight;
		internalNeurons[sinkID % Globals.numberOfInternalNeurons].inputs.Add(connectionValue);
		internalNeurons[sinkID % Globals.numberOfInternalNeurons].numberOfInputs++;
    }

	void createConnectionInput_Output(int sourceID, int sinkID, double connectionWeight)
	{
		double connectionValue = org.input.callInput(sourceID) * connectionWeight;
		outputs[sinkID % Globals.numberOfOutputSensors] = connectionValue;
	}

	void createConnectionInternalNeuron_Output(int sourceID, int sinkID, double connectionWeight)
	{

	}


	public void processGene(Gene gene)
	{
		int sourceType = gene.getIntValue(0, 1);
		int sourceID = gene.getIntValue(1, 5);

		int sinkType = gene.getIntValue(6, 1);
		int sinkID = gene.getIntValue(7, 5);

		int connectionSign = gene.getIntValue(12, 1) * (-1);
		double connectionWeight = connectionSign * (gene.getIntValue(13, 11) / 2048);

		if (sinkType == 1)
		{
			if (sourceType == 0)
			{
				createConnectionInput_InternalNeuron(sourceID, sinkID, connectionWeight);
            }
			else if (sourceType == 1) {
                createConnectionInternalNeuron_InternalNeuron(sourceID, sinkID, connectionWeight);
            }
		}
	}

}
