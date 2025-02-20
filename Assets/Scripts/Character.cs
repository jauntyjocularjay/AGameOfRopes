using UnityEngine;

abstract public class Character : Prop
{
    public CharacterData data;
    public Character target;
    public new void Start()
    {
        base.Start();
        data.will = data.maxWill;
        data.bindings = 0;
    }
    public int Will()
    {
        return data.will;
    }
    public void Will(int i)
    {
        data.will = i;
    }
    public void IncrementWill(int i = 1)
    {
        data.will += i;
    }
    public void SetAction(Action a)
    {
        data.action = a;
    }
    public int Bindings()
    {
        return data.bindings;
    }
    public void Bindings(int i)
    {
        data.bindings = i;
    }
    public void IncrementBind(int i)
    {
        data.bindings += i;
    }
    public void Attack(bool special = false)
    {
        Debug.Log($"{data.alias}.Attack()");
        target.IncrementWill(-data.damage * (special ? data.specialMultiplier : 1));
    }
    public void Bind()
    {
        Debug.Log($"{data.alias}.Bind()");
        target.IncrementBind(data.Bind());
    }
    public void Guard(bool reposte = false)
    {
        Debug.Log($"{data.alias}.Guard()");
        if(reposte)
        {
            Attack(true);
        }
    }
    public void Struggle()
    {
        Debug.Log($"{data.alias}.Struggle()");
        target.IncrementWill(-data.specialMultiplier * (data.maxWill - Will()) / data.maxWill);
    }
    public void Tease()
    {
        Debug.Log($"{data.alias}.Tease()");
        IncrementWill(data.damage & data.specialMultiplier);
    }
    abstract public int Damage();
}
