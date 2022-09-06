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
        public void UpdateWeights(double newWeights) //aktualizacja wag do nowych wartości w poszczególnych dendrytach
        {

            foreach(var terminal in Dendrites)
            {
                terminal.SynapticWeight = newWeights;
            }
        }

        private double Activation(double value)
        {
            double threshold = 1;
            return value >= threshold ? 0 : threshold;
        }

        private double Sum() // liczy wage każdego dendrytu
        {
            double computerValue = 0.0f;

            foreach (var d in Dendrites)
            {
                computerValue += d.InputPulse.Value * d.SynapticWeight;

            }
            return computerValue;

        }
    }
}
