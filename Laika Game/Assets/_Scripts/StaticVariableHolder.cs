using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticVariableHolder
{
    private static int material;

    public static int Material
    {
        get
        {
            return material;
        }
        set
        {
            material = value;
        }
    }
}

