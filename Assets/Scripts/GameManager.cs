using UnityEngine;

[ExecuteAlways]
public class GameManager : MonoBehaviour
{
    public int turn = 0;
    [Header("Iris")]
    public Iris iris;
    public CharacterData irisData;
    public int irisBindings;
    public int irisWill;
    [Header("Dirk")]
    public Dirk dirk;
    public CharacterData dirkData;
    public int dirkBindings;
    public int dirkWill;
    public int willThreshold = 4;

    void Update()
    {
        irisBindings = irisData.bindings;
        irisWill = irisData.will;
        dirkBindings = dirkData.bindings;
        dirkWill = dirkData.will;
    }

    public void Attack()
    {
        turn++;
        iris.Decide();
        dirk.action = Action.Attack;
    }
    public void Bind()
    {
        turn++;
        iris.Decide();
        dirk.action = Action.Bind;
    }
    public void Guard()
    {
        turn++;
        iris.Decide();
        dirk.action = Action.Guard;
    }
    public void Tease()
    {
        turn++;
        iris.Decide();
        dirk.action = Action.Tease;
    }

    public void Resolve()
    {
        if(iris.action == Action.Attack && dirk.action == Action.Attack){}
        else if(iris.action == Action.Guard && dirk.action == Action.Attack){}
        else if(iris.action == Action.Attack && dirk.action == Action.Guard){}
        else if(iris.action == Action.Guard && dirk.action == Action.Guard){}
        else if(iris.action == Action.Bind && dirk.action == Action.Attack){}
        else if(iris.action == Action.Attack && dirk.action == Action.Bind){}
        else if(iris.Will() <= willThreshold && dirk.action == Action.Tease){}
        else if(iris.action == Action.Tease && dirk.Will() <= willThreshold){}
    }
}
