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
    }
    override public int Damage()
    {
        return data.damage;
    }
}

