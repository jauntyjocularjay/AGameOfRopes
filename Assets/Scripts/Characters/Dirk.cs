using UnityEngine;

public class Dirk : Character
{
    new void Start()
    {
        base.Start();
        IncrementWill(12);
        data.damage = 1;
        data.bind = 1;
        data.specialMultiplier = 15;
    }
    override public int Damage()
    {
        return data.damage;
    }
    override public int Struggle()
    {
        return data.bind;
    }
}
