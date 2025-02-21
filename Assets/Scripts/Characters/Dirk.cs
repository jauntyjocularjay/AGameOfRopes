using UnityEngine;

[ExecuteAlways]
public class Dirk : Character
{
    new void Start()
    {
        base.Start();
        data.damage = 10;
        data.bind = 10;
        data.specialMultiplier = 15;
        teaseLines = new string[3]{"Getting tired yet?", "I think I'll write a song about my victory.", "You're fighting like you WANT to lose!"};
    }
    override public int Damage()
    {
        return data.damage;
    }
}

