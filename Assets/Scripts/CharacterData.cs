using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public int maxWill = 120;
    public int will;
    public int damage;
    public int maxBindings = 120;
    public int bindings;
    public int bind;
    public int specialMultiplier;



    



/*

damage = 2 * (CurrentBinding-MaxBinding)/MaxBinding

*/
}
