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
    override public int Struggle()
    {
        return data.bind;
    }
    override public void Attack(bool special = false)
    {
        Debug.Log("Dirk.Attack()");
        // int multiplier = special ? data.specialMultiplier : 1;

        // data.action = Action.Attack;
        // Debug.Log($"Dirk attacks to reduce will by {data.damage * multiplier}");
        // target.IncrementWill(-data.damage * multiplier);
    }
    override public void Bind()
    {
        Debug.Log("Dirk.Bind()");
    }
    override public void Guard()
    {
        Debug.Log("Dirk.Guard()");
        // data.action = Action.Guard;
        // target.IncrementWill(-data.damage);
    }
    override public void Tease()
    {
        Debug.Log("Dirk.Tease()");
        // data.action = Action.Tease;
        // target.IncrementWill(-data.damage);
    }
}

