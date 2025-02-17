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
    void FixedUpdate()
    {
        RegenerateStamina();
    }
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
    override public void Attack()
    {
        target.IncrementWill(-data.damage);
        IncrementStamina(-4);
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
