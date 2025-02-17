using UnityEngine;

abstract public class Character : Prop
{
    public int specialMultiplier;
    public int updateCounter = 0;
    public int countsPerUpdate;
    
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
    abstract public void Attack();
    public void Bind(){}
    public void Guard(){}
    public void Tease(){}
    abstract public int Damage();
    abstract public int Struggle();
}
