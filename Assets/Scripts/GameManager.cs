using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

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
        iris.GetComponent<Animator>().SetInteger("bindings", iris.Bindings());

        dirkAction = dirk.data.action;
        dirkBindings = dirk.data.bindings;
        dirkWill = dirk.data.will;

        if(dirkWill <= 0 || irisWill <= 0 || dirkBindings >= 120 || irisBindings >= 120)
        {
            LoadNextScene();
        }
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
                }
                break;
            case Action.Guard:
                if (dirk.data.action == Action.Attack)
                {
                    attackFlag = true;
                    dirkHitFlag = true;
                    iris.Attack();
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
                }
                break;
            case Action.Guard:
                audioManager.PlaySound(weaponGuard);
                if (iris.data.action == Action.Attack)
                {
                    attackFlag = true;
                    dirk.Attack();
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
                break;
            case Action.Tease:
                dirk.Tease();
                break;
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
    void LoadNextScene()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(levelIndex);
    }
}
