using UnityEngine;

[ExecuteAlways]
public class GameManager : MonoBehaviour
{
    public int willThreshold = 40;
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
    void Update()
    {
        irisAction = iris.data.action;
        irisBindings = iris.data.bindings;
        irisWill = iris.data.will;
        iris.GetComponent<Animator>().SetInteger("bindings", iris.Bindings());

        dirkAction = dirk.data.action;
        dirkBindings = dirk.data.bindings;
        dirkWill = dirk.data.will;
    }

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
            dirk.data.action == Action.Bind
        )
        {
            dirk.Bind();
        }
        else if
        (
            iris.data.action == Action.Bind && 
            dirk.data.action == Action.Attack
        )
        {
            dirk.Attack();
        }else if
        (
            iris.data.action == Action.Attack && 
            dirk.data.action == Action.Bind
        )
        {
            iris.Attack();
        }
        else if
        (
            iris.data.action == Action.Bind && 
            dirk.data.action == Action.Guard
        )
        {
            iris.Bind();
        }
        else if
        (
            iris.Will() <= willThreshold && 
            dirk.data.action == Action.Tease
        )
        {
            dirk.Tease();
        }
        else if
        (
            dirk.Will() <= willThreshold && 
            iris.data.action == Action.Tease
        )
        {
            iris.Tease();
        }
        else if
        (
            dirk.data.action == Action.Struggle
        )
        {
            dirk.Attack();
            dirk.IncrementWill(-dirk.Damage());
        }
        else if
        (
            iris.data.action == Action.Struggle
        )
        {
            iris.Attack();
            iris.IncrementWill(-iris.Damage());
        }

        iris.data.action = iris.Decide(); // sets up the action after the turn resolves so we can set up Iris' tell.
        irisAction = iris.data.action; // Queue up the next action
        if(iris.data.action == Action.Attack) iris.tells.Attack();
        if(iris.data.action == Action.Bind) iris.tells.Bind();
        if(iris.data.action == Action.Guard) iris.tells.Guard();
        
    }

    Action DirkTeaseOrStruggle()
    {
        return dirk.Bindings() > 60
            ? Action.Struggle
            : Action.Tease;
    }
}
