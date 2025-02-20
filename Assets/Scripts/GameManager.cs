using UnityEngine;

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

    public void Attack()
    {
        turn++;
        dirkAction = dirk.data.action;
        dirk.SetAction(Action.Attack);
        Resolve();
    }
    public void Bind()
    {
        turn++;
        dirk.SetAction(Action.Bind);
        Resolve();
    }
    public void Guard()
    {
        turn++;
        dirk.SetAction(Action.Guard);
        Resolve();
    }
    public void TeaseOrStruggle()
    {
        turn++;
        dirk.SetAction(DirkTeaseOrStruggle());
        Resolve();
    }
    public void Resolve()
    {
        if
        (
            iris.data.action == Action.Attack && 
            dirk.data.action == Action.Attack)
        {
            iris.Attack();
            dirk.Attack();
        }
        else if
        (
            iris.data.action == Action.Guard && 
            dirk.data.action == Action.Attack
        )
        {
            iris.Attack(true);
        }
        else if
        (
            iris.data.action == Action.Attack && 
            dirk.data.action == Action.Guard
        )
        {
            dirk.Attack(true);
        }
        else if
        (
            iris.data.action == Action.Guard && 
            dirk.data.action == Action.Guard
        )
        {
            Debug.Log("Iris and Dirk both guard");
        }
        else if
        (
            iris.data.action == Action.Guard && 
            dirk.data.action == Action.Bind && 
            dirk.Will() > iris.Will()
        )
        {
            dirk.Bind();
        }
        else if
        (
            iris.data.action == Action.Guard && 
            dirk.data.action == Action.Attack && 
            iris.Will() > dirk.Will()
        )
        {
            iris.Bind();
        }
        else if
        (
            iris.Will() <= willThreshold && 
            iris.Bindings() > bindingsThreshold && 
            dirk.data.action == Action.Tease
        )
        {
            dirk.Tease();
        }
        else if
        (
            dirk.Will() <= willThreshold && 
            dirk.Bindings() > bindingsThreshold && 
            iris.data.action == Action.Tease
        )
        {}
        else if
        (
            dirk.Will() <= willThreshold && 
            dirk.Bindings() > bindingsThreshold && 
            dirk.data.action == Action.Struggle
        )
        {}
        else if
        (
            dirk.Will() <= willThreshold && 
            dirk.Bindings() > bindingsThreshold && 
            iris.data.action == Action.Struggle
        )
        {}

        iris.data.action = iris.Decide(); // sets up the action after the turn resolves so we can set up Iris' tell.
        irisAction = iris.data.action;
    }

    Action DirkTeaseOrStruggle()
    {
        if(dirk.Bindings() > 60)
            return Action.Struggle;
        else
            return Action.Tease;
    }
}
