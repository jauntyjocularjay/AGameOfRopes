using System;
using UnityEngine;

public class Iris : Character
{
    new void Start()
    {
        base.Start();
        data.damage = 20;
        data.bind = 20;
        data.specialMultiplier = 2;
    }
    public void Decide()
    {
        int randomInt = Utils.NextInt(0,3);
        switch (randomInt) {
            case 0:
                data.action = Action.Attack;
                break;
            case 1:
                data.action = Action.Bind;
                break;
            case 2:
                data.action = Action.Guard;
                break;
            case 3:
                data.action = Action.Tease;
                break;
            default: throw new Exception("Util.NextInt(0,3) generated an invalid value");
        }
    }
    override public int Damage()
    {
        return 2 * (Bindings() - data.maxBindings) / data.maxBindings;
    }
    override public int Struggle()
    {
        return 2 * (data.maxWill - Will()) / data.maxWill;
    }
    override public void Attack(bool special = false)
    {
        Debug.Log("Iris.Attack()");
        // int multiplier = special ? data.specialMultiplier : 1;
        // target.IncrementWill(-data.damage * multiplier);
    }
    override public void Bind()
    {
        Debug.Log("Iris.Bind()");
        // target.IncrementBind(data.bind);
    }
    override public void Guard()
    {
        Debug.Log("Iris.Guard()");
        if(target.data.action == Action.Attack)
        {
            // Attack(true);
        }
    }
    override public void Tease()
    {
        Debug.Log("Iris.Tease()");
        // data.action = Action.Tease;
    }
}
