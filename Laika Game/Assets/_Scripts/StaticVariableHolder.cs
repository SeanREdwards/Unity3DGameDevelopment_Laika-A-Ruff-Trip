using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticVariableHolder
{
    private static int material;
    private static bool quest1_Done, quest2_Done;

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

    public static bool Quest1_Done
    {
        get
        {
            return quest1_Done;
        }
        set
        {
            quest1_Done = value;
        }

    }

    public static bool Quest2_Done
    {
        get
        {
            return quest2_Done;
        }
        set
        {
            quest2_Done = value;
        }

    }

}

