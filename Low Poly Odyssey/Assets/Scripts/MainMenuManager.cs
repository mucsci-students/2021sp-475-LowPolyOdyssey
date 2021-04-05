using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject main, credits, controls;
    
    void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowCredits()
    {
        main.SetActive(false);
        credits.SetActive(true);
    }

    public void LeaveCredits()
    {
        credits.SetActive(false);
        main.SetActive(true);
    }

    public void ShowControls()
    {
        main.SetActive(false);
        controls.SetActive(true);
    }

    public void LeaveControls()
    {
        controls.SetActive(false);
        main.SetActive(true);
    }
}
