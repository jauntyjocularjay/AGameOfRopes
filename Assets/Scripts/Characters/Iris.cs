using System;
using UnityEngine;

public class Iris : Character
{
    new void Start()
    {
        base.Start();
        IncrementWill(120);
        data.damage = 20;
        data.bind = 20;
        data.specialMultiplier = 20;
        countsPerUpdate = 10;
    }
    void FixedUpdate()
    {
        // RegenerateWill(); // @stretch goal 
    }
    void Decide()
    {
    }
    void RegenerateWill()
    {
        if(updateCounter < countsPerUpdate)
        {
            updateCounter++;
        }
        else
        {
            updateCounter = 0;
            IncrementWill();
        }
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
    override public void Attack()
    {
        target.IncrementWill(-data.damage);
    }

}
