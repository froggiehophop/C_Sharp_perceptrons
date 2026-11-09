using System.Collections;

namespace perceptrons_library;

//basic perceptron class. Linked together to form models
public class perceptron
{
    private double weight = 0.5;

    private perceptron(double weight)
    {
        this.weight = weight;
    }

    private void update(int error, double learningRate, double input)
    {
        weight = weight + learningRate * error * input;
    }

    private double output(double input)
    {
        return input * weight;
    }
}

public class linearAlgorithm
{
    private double[] layerOne;
    private double learningRate = 0.2;
    //ArrayList inputs = new ArrayList();
    private double bias = 1;

    private void initializeLayerOne(double[] input)
    {
        layerOne = new double[input.Length];
        Array.Fill(layerOne, 0.5);
    }
    
    public linearAlgorithm(double learningRate)
    {
        this.learningRate = learningRate;
    }

    private void updateBias(double error)
    {
        bias = bias + learningRate * error;
    }

    public double predict(double[] input)
    {
        double prediction = bias;
        for (int i = 0; i < input.Length; i++)
        {
            prediction += input[i] * layerOne[i];
        }
        return prediction;
    }

    private void updatePerceptrons(double[] input, double error)
    {
        for (int i = 0; i < layerOne.Length; i++)
        {
            layerOne[i] = layerOne[i] + input[i]*learningRate * error;
        }
        
    }

    //takes input and iterates through updating the model
    private void train(double[][] input, double[] lables, int epochs)
    {
        double err = 0.0;
        initializeLayerOne(input[0]);
        for (int i = 0; i < epochs; i++)
        {
            for (int j = 0; j < input.Length; j++)
            {
                err = lables[j] - predict(input[j]);
                updateBias(err);
                updatePerceptrons(input[j], err);
            }
            
        }
    }
}