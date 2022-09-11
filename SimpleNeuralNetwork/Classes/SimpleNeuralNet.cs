using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;

namespace SimpleNeuralNetwork.Classes
{
    class SimpleNeuralNet
    {
        public void Run()
        {
            NetworkModel model = new NetworkModel();

            model.Layers.Add(new NeuralLayer(2, 0.1, "Input"));
            model.Layers.Add(new NeuralLayer(1, 0.1, "Output"));

            model.Build();
            Console.WriteLine("---------Przed Treningiem---------");
            model.Print();
            Console.WriteLine();

            NeuralData X = new NeuralData(4);

        }
    }
}
