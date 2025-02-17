using UnityEngine;

[ExecuteAlways]
public class GameManager : MonoBehaviour
{
    [Header("Iris")]
    public CharacterData iris;
    public int irisBindings;
    public int irisWill;
    [Header("Dirk")]
    public CharacterData dirk;
    public int dirkBindings;
    public int dirkWill;

    void Update()
    {
        irisBindings = iris.bindings;
        irisWill = iris.will;
        dirkBindings = dirk.bindings;
        dirkWill = dirk.will;
    }
}
