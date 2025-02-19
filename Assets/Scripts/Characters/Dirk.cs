using UnityEngine;

[ExecuteAlways]
public class Dirk : Character
{
    int stamina = 120;
    new void Start()
    {
        base.Start();
        IncrementWill(120);
        data.damage = 10;
        data.bind = 10;
        data.specialMultiplier = 15;
        countsPerUpdate = 7;
        updateCounter = 0;
    }
    /*void FixedUpdate()
    {
        // RegenerateStamina(); // @stretch
    }*/
    void RegenerateStamina()
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
        return data.damage;
    }
    override public int Struggle()
    {
        return data.bind;
    }
    override public void Attack(bool special = false)
    {
        int multiplier = special ? specialMultiplier : 1;

        action = Action.Attack;
        target.IncrementWill(-data.damage * multiplier);
    }
    override public void Bind()
    {
        action = Action.Bind;
        target.IncrementWill(-data.damage);
    }
    override public void Guard()
    {
        action = Action.Guard;
        target.IncrementWill(-data.damage);
    }
    override public void Tease()
    {
        action = Action.Tease;
        target.IncrementWill(-data.damage);
    }
    public int Stamina()
    {
        return stamina;
    }
    public void Stamina(int i)
    {
        stamina = i;
    }
    public void IncrementStamina(int i)
    {
        stamina += i;
    }

}

