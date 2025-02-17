using UnityEngine;

public class Iris : Character
{



    new void Start()
    {
        IncrementWill(12);
        data.damage = 2;
        data.bind = 2;
        data.specialMultiplier = 20;
    }
    override public int Damage()
    {
        return 2 * (Bindings() - data.maxBindings) / data.maxBindings;
    }
    override public int Struggle()
    /*
        @todo 
        @stretch
    */
    {
        return 2 * (data.maxWill - Will()) / data.maxWill;
    }
}
