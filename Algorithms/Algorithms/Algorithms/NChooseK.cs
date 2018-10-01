using System;

public class NChooseK
{
    public float N;
    public float K;
    public float result;

    public NChooseK(int n, int k)
    {

        N = (float) n;
        K = (float) k;

        //Use the Multiplicative formula
        result = 1.0f;
        for (int i = 1; i <= K; i++)
        {
            result = result * ((N + 1 - i) / i); //Can also use ((N - (K - i)) / i);
        }
    }
}