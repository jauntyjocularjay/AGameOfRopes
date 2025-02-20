using TMPro;
using UnityEngine;

public class ButtonTease : MonoBehaviour
{
    TMP_Text tmp;
    string tease = "Tease";
    string struggle = "Struggle";
    public GameManager gameManager;

    void Start()
    {
        tmp = GetComponentInChildren<TMP_Text>();
        tmp.text = tease;
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = gameManager.dirk.Bindings() > 60
            ? struggle : tease;
    }
}
