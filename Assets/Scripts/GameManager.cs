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

    public void Setup()
    {
        turn++;
        iris.Decide();
    }
    public void Attack()
    {
        Setup();
        dirk.action = Action.Attack;
        Resolve();
    }
    public void Bind()
    {
        Setup();
        dirk.action = Action.Bind;
        Resolve();
    }
    public void Guard()
    {
        Setup();
        dirk.action = Action.Guard;
        Resolve();
    }
    public void Tease()
    {
        Setup();
        dirk.action = Action.Tease;
        Resolve();
    }
    public void Resolve()
    {
        if(iris.action == Action.Attack && dirk.action == Action.Attack)
        {
            iris.Attack();
            dirk.Attack();
        }
        else if(iris.action == Action.Guard && dirk.action == Action.Attack)
        {
            iris.Attack(true);
        }
        else if(iris.action == Action.Attack && dirk.action == Action.Guard){}
        else if(iris.action == Action.Guard && dirk.action == Action.Guard){}
        else if(iris.action == Action.Bind && dirk.action == Action.Attack){}
        else if(iris.action == Action.Attack && dirk.action == Action.Bind){}
        else if(iris.Will() <= willThreshold && dirk.action == Action.Tease){}
        else if(iris.action == Action.Tease && dirk.Will() <= willThreshold){}
    }
}
