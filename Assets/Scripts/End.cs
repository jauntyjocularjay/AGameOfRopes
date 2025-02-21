using UnityEngine;

public class End : MonoBehaviour
{
    public Sprite lose;
    public Sprite win;
    public CharacterData irisData;
    public CharacterData dirkData;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(dirkData.bindings >= 120 || dirkData.will <= 0)
            spriteRenderer.sprite = lose;
        else
            spriteRenderer.sprite = win;
    }
}
