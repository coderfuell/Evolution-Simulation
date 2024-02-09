using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.VisualScripting.FullSerializer;

public class InternalNeuron
{
	public int numberOfInputs = 0;

	public List<double> inputs = new List<double>();

	public double giveOutput()
	{
		if (numberOfInputs == 0) return 0;
		double sum = 0;
		for (int i = 0; i< numberOfInputs; i++)
		{
			sum += inputs[i];
		}
		return Math.Tanh(sum);
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
		for (int i = 0;i<Globals.numberOfInternalNeurons; i++)
		{
			internalNeurons[i] = new InternalNeuron();
		}
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
		double connectionValue = internalNeurons[sourceID % Globals.numberOfInternalNeurons].giveOutput() * connectionWeight;
		outputs[sinkID % Globals.numberOfOutputSensors] = connectionValue;
    }


	public void processGene(Gene gene)
	{
		int sourceType = gene.getIntValue(0, 1);
		int sourceID = gene.getIntValue(1, 5);

		int sinkType = gene.getIntValue(6, 1);
		int sinkID = gene.getIntValue(7, 5);

		int connectionSign = gene.getIntValue(12, 1) * (-1);
		double connectionWeight = connectionSign * ((float)gene.getIntValue(13, 11) / 2048);

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
		else if (sinkType == 0)
		{
			if (sourceType == 0)
			{
				createConnectionInput_Output(sourceID, sinkID, connectionWeight);
			}
			else if (sourceType == 1)
			{
				createConnectionInternalNeuron_Output(sourceID, sinkID, connectionWeight);
			}
		}
	}

	void processGenome()
	{
        for (int i = 1;i<Globals.GenomeLength;i++)
		{
			processGene(org.genome.geneList[i]);
		}
	}

	public void processOutput()
	{
		processGenome();
		double max = 0;
		int maxIndex = -1;
		for (int i = 0;i<Globals.numberOfOutputSensors;i++)
		{
            if (outputs[i] >  max)
			{
				max = outputs[i];
				maxIndex = i;
			}
		}
		max = Math.Tanh(max);
		if (Globals.probabilityFunction(max) > 0)
		{
			org.output.callOutput(maxIndex);
		}
	}

}



