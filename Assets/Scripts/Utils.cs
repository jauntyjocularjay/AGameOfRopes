using System;
using UnityEngine;







public class Utils : MonoBehaviour
{
    readonly static System.Random r = new ();

    public static int NextInt(Int32 a, Int32 b)
    {
        return r.Next(a,b);
    }
    public static int NextInt(Int32 b)
    {
        return Utils.NextInt(0,b);
    }
    public static int NextInt()
    {
        return r.Next();
    }
}






