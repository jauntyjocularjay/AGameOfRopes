using UnityEngine;

public abstract class Character : Prop
{
    int will;
    int bindings;
    public float specialMultiplier;
    public CharacterData data;
    public Character target;
    public new void Start()
    {
        base.Start();
        will = data.maxWill;
        bindings = 0;
    }
    void Update()
    {
        
    }
    public int Will()
    {
        return will;
    }
    public void IncrementWill(int i)
    {
        will += i;
    }
    public int Bindings()
    {
        return bindings;
    }
    public void IncrementBind(int i)
    {
        bindings += i;
    }
    public void Attack()
    {
        target.IncrementWill(-data.damage);
    }
    public void Bind()
    {
        if(target.Will() < Will())
        {
            target.IncrementBind(20);
            // target.IncrementWill(-20);
        }
    }
    public void Guard()
    {}
    public void Tease()
    {}

    public abstract int Damage();
    public abstract int Struggle();
}
