using UnityEngine;

[ExecuteAlways]
public class Dirk : Character
{
    public Sprite dirkbound0;
    public Sprite dirkbound1;
    public Sprite dirkbound2;
    public Sprite dirkbound3;
    public Sprite dirkbound4;
    new void Start()
    {
        base.Start();
        data.damage = 10;
        data.bind = 10;
        data.specialMultiplier = 2;
    }

    void Update()
    {
        if(data.bindings < 30) SpriteRenderer().sprite = dirkbound0;
        else if(data.bindings < 60) SpriteRenderer().sprite = dirkbound1;
        else if(data.bindings < 90) SpriteRenderer().sprite = dirkbound2;
        else if(data.bindings < 90) SpriteRenderer().sprite = dirkbound3;
        else SpriteRenderer().sprite = dirkbound4;
    }
}

