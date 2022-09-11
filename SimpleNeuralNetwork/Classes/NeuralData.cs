using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork.Classes
{
    class NeuralData
    {
        public double[][] Data { get; set; }

        int counter = 0;

        public NeuralData(int rows)
        {
            Data = new double[rows][];
        }
        public void Add(params double[] rec)
        {
            Data[counter] = rec;
            counter++;
        }
    }
}
