using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork.Classes
{
    class Dendrite
    {
        public Pulse InputPulse { get; set; }
        public double SynapticWeight { get; set; }

        public bool Learnable { get; set; } = true;
    }
}
