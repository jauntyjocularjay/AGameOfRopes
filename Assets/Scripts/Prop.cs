using UnityEngine;

public abstract class Prop : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public SpriteRenderer SpriteRenderer()
    {
        return spriteRenderer;
    }

}
