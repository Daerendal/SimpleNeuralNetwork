using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork.Classes
{
    class Neuron
    {
        public List<Dendrite> Dendrites { get; set; }

        public Pulse OutputPulse { get; set; }  
        private double Weight { get; set; }

        public Neuron()
        {
            Dendrites = new List<Dendrite>();
            OutputPulse = new Pulse();
        }
        public void Fire()
        {
            OutputPulse.Value = Sum();
            OutputPulse.Value = Activation(OutputPulse.Value);

        }
        public void UpdateWeights(double newWeights)
        {

            foreach(var terminal in Dendrites)
            {
                terminal.SynapticWeight = newWeights;
            }
        }

        private double Activation(double value)
        {
            throw new NotImplementedException();
        }

        private double Sum()
        {
            throw new NotImplementedException();
        }
    }
}
