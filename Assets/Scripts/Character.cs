using UnityEngine;

public class Character : MonoBehaviour
{
    int will = 12;
    int bind = 12;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementWill(int i)
    {
        will += i;
    }
    public void IncrementBind(int i)
    {
        bind += i;
    }
}
