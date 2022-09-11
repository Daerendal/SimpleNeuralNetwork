// See https://aka.ms/new-console-template for more information



using SimpleNeuralNetwork.Classes;

NetworkModel model = new NetworkModel();
model.Layers.Add(new NeuralLayer(2, 0.1, "Input"));
model.Layers.Add(new NeuralLayer(2, 0.1, "Hidden"));
model.Layers.Add(new NeuralLayer(1, 0.1, "Output"));

model.Build();
model.Print();