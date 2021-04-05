using UnityEngine;
using UnityEngine.UI;

public class PLight : MonoBehaviour
{
    public Sprite on, off;
    public bool startOn = false;
    bool lit = false;

    void Start()
    {
        if (startOn)
            Toggle();
    }
    
    public void Toggle()
    {
        lit = !lit;
        GetComponent<Image>().sprite = lit ? on : off;
    }

    public bool IsLit()
    {
        return lit;
    }
}
