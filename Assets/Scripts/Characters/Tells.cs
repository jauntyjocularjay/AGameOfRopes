using UnityEngine;

public class Tells : Prop
{
    public Sprite attack;
    public Sprite bind;
    public Sprite guard;
    public void Attack()
    {
        SpriteRenderer().sprite = attack;
    }
    public void Bind()
    {
        SpriteRenderer().sprite = bind;
    }
    public void Guard()
    {
        SpriteRenderer().sprite = guard;
    }
}
