using UnityEngine;

public class Character : Prop
{
    int will = 12;
    int bind = 12;
    public Character target;
    public new void Start()
    {
        base.Start();
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
    public int Bind()
    {
        return bind;
    }
    public void IncrementBind(int i)
    {
        bind += i;
    }
    public void Attack()
    {
        target.IncrementWill(-2);
        IncrementWill(1);
    }
    public void BindTarget()
    {
        if(target.Will() < Will())
        {
            target.IncrementBind(2);
            target.IncrementWill(-2);
        }
    }
}
