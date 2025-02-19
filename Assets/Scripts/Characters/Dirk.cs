using UnityEngine;

[ExecuteAlways]
public class Dirk : Character
{
    int stamina = 120;
    new void Start()
    {
        base.Start();
        data.damage = 10;
        data.bind = 10;
        data.specialMultiplier = 15;
    }
  /*void FixedUpdate()
    {
        // RegenerateStamina(); // @stretch
    }*/
  /*void RegenerateStamina()
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
    }*/
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

