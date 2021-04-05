using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public GameManager gameManager;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PauseTheGame(){
        gameManager.PauseGame();
    }
    void ResumeTheGame(){
        gameManager.ResumeGame();
    }
}
