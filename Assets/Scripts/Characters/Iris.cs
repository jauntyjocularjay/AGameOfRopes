using System;

public class Iris : Character
{
    new void Start()
    {
        base.Start();
        data.damage = 20;
        data.bind = 20;
        data.specialMultiplier = 3;
        data.action = Decide();
    }
    public Action Decide()
    {
        int a = Bindings() > 60 ? 1 : 0;
        int b = 3;

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
}
