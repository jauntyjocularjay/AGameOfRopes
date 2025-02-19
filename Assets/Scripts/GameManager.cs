using UnityEngine;
using UnityEngine.UIElements;

[ExecuteAlways]
public class GameManager : MonoBehaviour
{
    public int turn = 0;
    [Header("Iris")]
    public Iris iris;
    public CharacterData irisData;
    public Action irisAction;
    public int irisBindings;
    public int irisWill;
    [Header("Dirk")]
    public Dirk dirk;
    public CharacterData dirkData;
    public Action dirkAction;
    public int dirkBindings;
    public int dirkWill;
    public int willThreshold = 40;
    public int bindingsThreshold = 40;

    void Update()
    {
        irisBindings = irisData.bindings;
        irisWill = irisData.will;
        dirkBindings = dirkData.bindings;
        dirkWill = dirkData.will;
        dirkAction = dirk.data.action;
        irisAction = iris.data.action;
    }

    public void Setup()
    {
        turn++;
    }
    public void Attack()
    {
        Setup();
        dirk.SetAction(Action.Attack);
        Resolve();
    }
    public void Bind()
    {
        Setup();
        dirk.SetAction(Action.Bind);
        Resolve();
    }
    public void Guard()
    {
        Setup();
        dirk.SetAction(Action.Guard);
        Resolve();
    }
    public void Tease()
    {
        Setup();
        dirk.SetAction(Action.Tease);
        Resolve();
    }
    public void Resolve()
    {
        irisAction = iris.data.action;
        dirkAction = dirk.data.action;

        if(iris.data.action == Action.Attack && dirk.data.action == Action.Attack)
        {
            iris.Attack();
            dirk.Attack();
        }
        else if(iris.data.action == Action.Guard && dirk.data.action == Action.Attack)
        {
            iris.Attack(true);
        }
        else if(iris.data.action == Action.Attack && dirk.data.action == Action.Guard)
        {
            dirk.Attack(true);
        }
        else if(iris.data.action == Action.Guard && dirk.data.action == Action.Guard)
        {
            iris.Attack(true);
        }
        else if(iris.data.action == Action.Attack && dirk.data.action == Action.Bind)
        {
            if(dirk.Will() > iris.Will())
            {
                dirk.Bind();
            }
        }
        else if(iris.data.action == Action.Bind && dirk.data.action == Action.Attack)
        {
            if(iris.Will() > dirk.Will())
            {
                iris.Bind();
            }
        }
        else if(iris.Will() <= willThreshold && iris.Bindings() > bindingsThreshold && dirk.data.action == Action.Tease)
        {}
        else if(iris.data.action == Action.Tease && dirk.Bindings() > bindingsThreshold && dirk.Will() <= willThreshold)
        {}
    }
}
