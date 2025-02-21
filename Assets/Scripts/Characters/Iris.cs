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
        data.action = Decide();
        teaseLines = new string[3] {"Oh nooo~, a stringed instrument. I'm sooo scared.", "When I win, we need to talk about changing your outfit. I have so many ideas!", "I wonder which part of me you'll enjoy serving the most..."};
    }
    public Action Decide()
    {
        int a = Bindings() > 60 
            ? 1 : 0;
        int b = Bindings() > 60 
            ? 2 : 3;

        int randomInt = Utils.NextInt(a,b);
        switch (randomInt) {
            case 0:
                return Action.Attack;
            case 1:
                return Action.Bind;
            case 2:
                return Action.Guard;
            case 3:                
                Action action = Bindings() > Will() 
                    ? Action.Struggle : Action.Tease;
                return action;
            default: throw new Exception($"Util.NextInt({a},{b}) generated an invalid value");
        }
    }
    override public int Damage()
    {
        return 2 * (Bindings() - data.maxBindings) / data.maxBindings;
    }
}
