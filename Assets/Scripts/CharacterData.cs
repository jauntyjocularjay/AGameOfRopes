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
<<<<<<< HEAD
=======
    public int bindings;
>>>>>>> dev
    public AudioSource a_Attack;
    public AudioSource a_Guard;
    public AudioSource a_Struggle;
    public int damage;
    public int bind;
    public int specialMultiplier;

    public int Bind()
    {
        return bind;
    }



    



}
