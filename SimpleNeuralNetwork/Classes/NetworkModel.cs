using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;

namespace SimpleNeuralNetwork.Classes
{
    class NetworkModel
    {
        public List<NeuralLayer> Layers { get; set; }

        public NetworkModel()
        { 
            Layers = new List<NeuralLayer>(); 
        }
        private void ComputeOutput()
        {
            bool first = true;

            foreach (NeuralLayer layer in Layers)
            {

                // mija pierwszy szereg neuronów, ponieważ nie będzie on zmieniał ich wag - tylko każdą następna
                if(first)
                {
                    first = false;
                    continue;
                }

                layer.Forward();
            }
        }
        private void OptimizeWeights(double accuracy)
        {
            float lr = 0.1f;
            // jeśli dokładnosc jest 1, jest dobrze, jeśli dokładnośc jest ponad 1 - zmniejsza ją, jeśli jest mniejsza niż 1 - zwiększa ja

            if (accuracy == 1)
            {
                return;
            }
            if (accuracy > 1)
            {
                lr = -lr;
            }

            foreach(NeuralLayer layer in Layers)
            {

                layer.Optimize(lr,1);
            }


        }
        public void AddLayer(NeuralLayer layer)
        {
            int dendriteCount = 1; // to mówi nam ile dendrytów otrzyma nastepny layer

            if (Layers.Count > 0)
            {
                dendriteCount = Layers.Last().Neurons.Count;
            }
            foreach (var element in layer.Neurons)
            {
                for (int i =0; i < dendriteCount; i++)
                {
                    element.Dendrites.Add(new Dendrite());
                }

            }
        }
        public void Build()
        {
            int i = 0;
            foreach(var layer in Layers)
            {
                if( i>= Layers.Count -1) // bo od 0
                {
                    break;
                }
                var nextLayer = Layers[i+1];
                CreateNetwork(layer, nextLayer);

                i++;
            }
        }
        public void Train(NeuralData X, NeuralData Y, int iterations, double learningRate = 0.1)
        {
            throw new NotImplementedException();
        }
        public void Print()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Neurons");
            dt.Columns.Add("Weight");

            foreach(var layer in Layers)
            {
                DataRow row = dt.NewRow();
                row[0] = layer.Name;
                row[1] = layer.Neurons.Count;
                row[2] = layer.Weight; 

                dt.Rows.Add(row);

            }
            ConsoleTableBuilder builder = ConsoleTableBuilder.From(dt);
            builder.ExportAndWrite();
        }

        private void CreateNetwork(NeuralLayer connectingFrom, NeuralLayer connectingTo)
        {
            foreach (var to in connectingTo.Neurons)
            {
                foreach(var from in connectingFrom.Neurons)
                {
                    to.Dendrites.Add(new Dendrite() { InputPulse = from.OutputPulse, SynapticWeight = connectingTo.Weight });

                }

            }
        }
    }
}
