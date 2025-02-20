using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public string alias;
    public Action action;
    public int maxWill = 120;
    public int will;
    public int maxBindings = 120;
    public int bindings;
    public int damage;
    public int bind;
    public int specialMultiplier;

    public int Bind()
    {
        return bind;
    }



    



/*

damage = 2 * (CurrentBinding-MaxBinding)/MaxBinding

*/
}
