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
  /*void FixedUpdate()
    {
        // RegenerateWill(); // @stretch goal
    } */
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
    public void Decide()
    {
        int randomInt = Utils.NextInt(0,3);
        switch (randomInt) {
            case 0:
                Attack();
                break;
            case 1:
                Bind();
                break;
            case 2:
                Guard();
                break;
            case 3:
                Tease();
                break;
            default: throw new Exception("Util.NextInt(0,3) generated an invalid value");
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
    override public void Attack(bool special = false)
    {
        int multiplier = special ? specialMultiplier : 1;
        target.IncrementWill(-data.damage * multiplier);
    }
    override public void Bind()
    {
        action = Action.Bind;
        target.IncrementBind(data.bind);
    }
    override public void Guard()
    {
        action = Action.Guard;
    }
    override public void Tease()
    {
        action = Action.Tease;
    }
}
