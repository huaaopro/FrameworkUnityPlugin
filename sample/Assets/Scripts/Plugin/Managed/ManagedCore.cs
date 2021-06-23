using System.Collections;
using System.Collections.Generic;
using FrameworkUnityPlugin;
using UnityEngine;

public static class ManagedCore
{
    public static int Add(int a, int b)
    {
        return Utility.MathX.Add(a, b);
    }

    public static int Sub(int a, int b)
    {
        return Utility.MathX.Sub(a, b);
    }

    public static int Div(int a, int b)
    {
        return Utility.MathX.Div(a, b);
    }

    public static int Mul(int a, int b)
    {
        return Utility.MathX.Mul(a, b);
    }
}
