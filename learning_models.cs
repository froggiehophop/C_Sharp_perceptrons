using System.Collections;

namespace perceptrons_library;

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
    private double learningRate = 0.2;
    ArrayList inputs = new ArrayList();
    private double bias = 1;
    
    public linearAlgorithm(double learningRate)
    {
        this.learningRate = learningRate;
    }

    private void updateBias(int error)
    {
        bias = bias + learningRate * error;
    }
    
}