using System;
using Unity.VisualScripting;


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
