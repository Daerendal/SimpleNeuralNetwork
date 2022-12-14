using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork.Classes
{
    class NeuralLayer
    {
        public List<Neuron> Neurons;

        public string Name { get; set; }

        public double Weight { get; set; }

        public void Forward()
        {
            foreach (Neuron neuron in Neurons)
            {
                neuron.Fire();
            }

        }

        public NeuralLayer(int count, double initialWeight, string name = "")
        {
            Neurons = new List<Neuron>();

            for (int i = 0; i < count; i++)
            {
                Neurons.Add(new Neuron());
            }
            Weight = initialWeight;
            Name = name;
        }

        public void Optimize(double learningRate,double delta)
        {
            Weight += learningRate * delta;
            foreach( var neuron in Neurons )
            {
                neuron.UpdateWeights(Weight);
            }

        }
        public void Log()
        {
            Console.WriteLine("{0}, Weight: {1}", Name,Weight);
        }

    }
}
