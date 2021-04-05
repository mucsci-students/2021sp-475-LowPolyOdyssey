using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public MissionManager mission;
    public GameObject pauseMenu;
    public GameObject player;
    private bool isPaused;

    public Text score;
    public Text timer;
    public Text coords;
    float currTime = 0f, startTimeEasy = 150f, startTimeMed = 120f, startTimeHard = 60f;
    public float deliveryScore, totalScore;
    
    void Update()
    {
        if(Input.GetKeyDown("p")){
            if(isPaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }

        totalScore = Mathf.Round(totalScore);

        currTime -= 1 * Time.deltaTime;
        timer.text = currTime.ToString("0");
        score.text = totalScore.ToString();

        if(currTime <= 0)
        {
            timer.enabled = false;
            if(mission.activeMission)
            {
                mission.MissionRestart();
            }
        }

        if (timer.enabled)
        {
            if (!coords.enabled)
                coords.enabled = true;
            Vector3 coordsVec = mission.GetCurrentEndMission().transform.position;
            coords.text = string.Format("Distance: {0}", (100 * Vector3.Distance(coordsVec, player.transform.position)).ToString("0"));
        }
        else
            coords.enabled = false;
    }

    public void StartTimer()
    {
        if(mission.missionOneE || mission.missionFourE)
        {
            currTime = startTimeEasy;
            timer.enabled = true;
        }
        else if(mission.missionTwoM || mission.missionFiveM)
        {
            currTime = startTimeMed;
            timer.enabled = true;
        }
        else if(mission.missionThreeH || mission.missionSixH)
        {
            currTime = startTimeHard;
            timer.enabled = true;
        }
    }

    public void EndTimer()
    {
        deliveryScore = currTime;
        totalScore += deliveryScore;
        timer.enabled = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        player.GetComponent<CameraController>().DisableMovement();
        player.GetComponent<PlayerController>().DisableMovement();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        isPaused = true;
    }
     
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        player.GetComponent<CameraController>().EnableMovement();
        player.GetComponent<PlayerController>().EnableMovement();
        Time.timeScale = 1;
        isPaused = false;
    }

    public void ReplayGame(){
        SceneManager.LoadScene("Space");
    }

    public void BackToMainMenu(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
}
