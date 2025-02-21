using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Data", menuName = "Data/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public string alias;
    public Action action;
    public int maxWill = 120;
    public int will;
    public int maxBindings = 120;
    public int bindings;
    public AudioResource a_Attack;
    public AudioResource a_Guard;
    public AudioResource a_Struggle;
    public int damage;
    public int bind;
    public int specialMultiplier;

    public int Bind()
    {
        return bind;
    }



    



}
