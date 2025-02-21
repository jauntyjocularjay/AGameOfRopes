using UnityEngine;
using UnityEngine.Audio;

[ExecuteAlways]
public class GameManager : MonoBehaviour
{
    public int willThreshold = 40;
    public int turn = 0;
    public AudioManager audioManager;
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

    public AudioResource weaponAttack;
    public AudioResource weaponGuard;
    public AudioResource weaponBind;
    void Update()
    {
        irisAction = iris.data.action;
        irisBindings = iris.data.bindings;
        irisWill = iris.data.will;

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
        bool attackFlag = false;
        bool guardFlag = false;
        bool irisHitFlag = false;
        bool dirkHitFlag = false;
        bool bindFlag = false;
        switch (iris.data.action)
        {

            case Action.Attack:
                if (dirk.data.action != Action.Guard)
                {
                    attackFlag = true;
                    dirkHitFlag = true;
                    iris.Attack();
                    audioManager.PlaySound(iris.data.a_Attack);
                }
                break;
            case Action.Guard:
                audioManager.PlaySound(weaponGuard);
                audioManager.PlaySound(iris.data.a_Guard);
                if (dirk.data.action == Action.Attack)
                {
                    attackFlag = true;
                    dirkHitFlag = true;
                    iris.Attack();
                    audioManager.PlaySound(iris.data.a_Attack);
                }    
                break;
            case Action.Bind:
                if (dirk.data.action != Action.Attack)
                {
                    bindFlag = true;
                    iris.Bind();
                }
                break;
            case Action.Struggle:
                iris.IncrementWill(-iris.Damage());
                iris.IncrementBind(-iris.data.bind);
                audioManager.PlaySound(iris.data.a_Struggle);
                break;
            case Action.Tease:
                iris.Tease();
                break;
        }

        switch (dirk.data.action)
        {
            case Action.Attack:
                if (iris.data.action != Action.Guard)
                {
                    attackFlag = true;
                    irisHitFlag = true;
                    dirk.Attack();
                    audioManager.PlaySound(dirk.data.a_Attack);
                }
                break;
            case Action.Guard:
                audioManager.PlaySound(weaponGuard);
                audioManager.PlaySound(dirk.data.a_Guard);
                if (iris.data.action == Action.Attack)
                {
                    attackFlag = true;
                    dirk.Attack();
                    audioManager.PlaySound(dirk.data.a_Attack);
                }
                break;
            case Action.Bind:
                if (iris.data.action != Action.Attack)
                {
                    bindFlag = true;
                    dirk.Bind();
                }
                break;
            case Action.Struggle:
                dirk.IncrementWill(-dirk.Damage());
                dirk.IncrementBind(-dirk.data.bind);
                audioManager.PlaySound(dirk.data.a_Struggle);
                break;
            case Action.Tease:
                dirk.Tease();
                break;
        }

        if (attackFlag) { audioManager.PlaySound(weaponAttack); }
        if (guardFlag) { audioManager.PlaySound(weaponGuard); }
        if (irisHitFlag) { audioManager.PlaySound(iris.data.a_Guard); }
        if (dirkHitFlag) { audioManager.PlaySound(dirk.data.a_Guard); }
        if (bindFlag) { audioManager.PlaySound(weaponBind); }

        //if
        //(
        //    iris.data.action == Action.Attack && 
        //    dirk.data.action == Action.Attack)
        //{
        //    iris.Attack();
        //    audioManager.PlaySound(iris.data.a_Attack);
        //    dirk.Attack();
        //    audioManager.PlaySound(dirk.data.a_Attack);
        //    audioManager.PlaySound(weaponAttack);
        //}
        //else if 
        //(
        //    iris.data.action == Action.Guard && 
        //    dirk.data.action == Action.Attack
        //)
        //{
        //    iris.Attack(true);
        //    audioManager.PlaySound(weaponGuard);
        //    audioManager.PlaySound(iris.data.a_Attack);;
        //}
        //else if
        //(
        //    iris.data.action == Action.Attack && 
        //    dirk.data.action == Action.Guard
        //)
        //{
        //    dirk.Attack(true);
        //    audioManager.PlaySound(weaponGuard);
        //    audioManager.PlaySound(dirk.data.a_Attack);
        //}
        //else if
        //(
        //    iris.data.action == Action.Guard && 
        //    dirk.data.action == Action.Guard
        //)
        //{
        //    Debug.Log("Iris and Dirk both guard");
        //}
        //else if
        //(
        //    iris.data.action == Action.Guard && 
        //    dirk.data.action == Action.Bind
        //)
        //{
        //    dirk.Bind();
        //    audioManager.PlaySound(weaponBind);
        //    audioManager.PlaySound(iris.data.a_Guard);
        //}
        //else if
        //(
        //    iris.data.action == Action.Bind && 
        //    dirk.data.action == Action.Attack
        //)
        //{
        //    dirk.Attack();
        //    audioManager.PlaySound(dirk.data.a_Attack);
        //    audioManager.PlaySound(iris.data.a_Struggle);
        //}else if
        //(
        //    iris.data.action == Action.Attack && 
        //    dirk.data.action == Action.Bind
        //)
        //{
        //    iris.Attack();
        //    audioManager.PlaySound(iris.data.a_Attack);
        //    audioManager.PlaySound(dirk.data.a_Struggle);
        //}
        //else if
        //(
        //    iris.data.action == Action.Bind && 
        //    dirk.data.action == Action.Guard
        //)
        //{
        //    iris.Bind();
        //    audioManager.PlaySound(dirk.data.a_Struggle);
        //}
        //else if
        //(
        //    iris.Will() <= willThreshold && 
        //    dirk.data.action == Action.Tease
        //)
        //{
        //    dirk.Tease();
        //}
        //else if
        //(
        //    dirk.Will() <= willThreshold && 
        //    iris.data.action == Action.Tease
        //)
        //{
        //    iris.Tease();
        //}
        //else if
        //(
        //    dirk.data.action == Action.Struggle
        //)
        //{
        //    dirk.Attack();
        //    dirk.IncrementWill(-dirk.Damage());
        //}
        //else if
        //(
        //    iris.data.action == Action.Struggle
        //)
        //{
        //    iris.Attack();
        //    iris.IncrementWill(-iris.Damage());
        //}

        iris.data.action = iris.Decide(); // sets up the action after the turn resolves so we can set up Iris' tell.
        irisAction = iris.data.action; // Queue up the next action
    }

    Action DirkTeaseOrStruggle()
    {
        return dirk.Bindings() > 60
            ? Action.Struggle
            : Action.Tease;
    }
}
