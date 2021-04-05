using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public GameManager manager;
    [Header("Player")]
    public GameObject player;

    [Header("Win Panel")]
    public GameObject win;
    public Text scoreText;
    float finalScore;
    [Header("Mission Objects")]
    public GameObject stationHatch;
    public GameObject[] spaceShips;
    public GameObject[] SSHatches;

    [Header("Mission Sounds")]
    public AudioSource StationAduio;
    public AudioSource SpaceShip1;
    public AudioSource SpaceShip2;
    public AudioSource SpaceShip3;
    public AudioClip hatchSound;
    
    [Header("Mission Prompts")]
    public GameObject missionOneprompt;
    public GameObject missionTwoprompt;
    public GameObject missionThreeprompt;
    public GameObject missionFourprompt; 
    public GameObject missionFiveprompt;
    public GameObject missionSixprompt;

    [Header("Mission End Prompts")]
    public GameObject missionEndPromptOne;
    public GameObject missionEndPromptTwo;
    public GameObject missionEndPromptThree;
    public GameObject missionEndPromptFour;
    public GameObject missionEndPromptFive;
    public GameObject missionEndPromptSix;
    
    [Header("Mission Begin GameObjetcs")]
    public GameObject easyMission;
    public GameObject medMission;
    public GameObject hardMission;
    public GameObject easyMissionTwo;
    public GameObject medMissionTwo;
    public GameObject hardMissionTwo;
    
    [Header("Mission End GameObjects")]
    public GameObject easyEnd;
    public GameObject medEnd;
    public GameObject hardEnd;
    public GameObject easyEndTwo;
    public GameObject medEndTwo;
    public GameObject hardEndTwo;

    [Header("Mission Animations")]
    public AnimationClip spaceShipEasyBegin;
    public AnimationClip spaceShipEasyEnd;
    public AnimationClip spaceShipMedBegin;
    public AnimationClip spaceShipMedEnd;
    public AnimationClip spaceShipHardBegin;
    public AnimationClip spaceShipHardEnd;
    public AnimationClip hatchOpen;
    public AnimationClip hatchClose;
    private Animation anim;
    private Animation anim2;

    bool acceptMissionPanel, endMissionpanel;

    [Header("Active Missions (bool)")]
    public bool activeMission;
    public bool missionOneE, missionTwoM, missionThreeH, missionFourE, missionFiveM, missionSixH;

    public int[] randomMissions;
    void Start()
    {
        missionOneE = true;
        easyMission.SetActive(true);
        anim = stationHatch.GetComponent<Animation>();
        anim.Play("SStationPRelease");

        randomMissions = new int[5];
        for(int i = 0; i < 5; ++i)
        {
            randomMissions[i] = i;
        }
    }
    // plays animations no sound, 1,2,3 has the station hatch close
    // 4,5,6 has the space ship fly away when accepted from it
    void Update()
    {
        if(acceptMissionPanel)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                activeMission = true;
                endMissionpanel = true;
                if(missionOneE)
                {
                    easyEnd.SetActive(true);
                    manager.StartTimer();
                    easyMission.SetActive(false);
                    anim = stationHatch.GetComponent<Animation>();
                    anim.Play("SStationPClose");
                }
                else if(missionTwoM)
                {
                    medEnd.SetActive(true);
                    manager.StartTimer();
                    medMission.SetActive(false);
                    anim = stationHatch.GetComponent<Animation>();
                    anim.Play("SStationPClose");
                }
                else if(missionThreeH)
                {
                    hardEnd.SetActive(true);
                    manager.StartTimer();
                    hardMission.SetActive(false);
                    anim = stationHatch.GetComponent<Animation>();
                    anim.Play("SStationPClose");
                }
                else if(missionFourE)
                {
                    easyEndTwo.SetActive(true);
                    manager.StartTimer();
                    easyMissionTwo.SetActive(false);
                    anim = spaceShips[0].GetComponent<Animation>();
                    anim.Play("SShipEasyLeave");
                }
                else if(missionFiveM)
                {
                    medEndTwo.SetActive(true);
                    manager.StartTimer();
                    medMissionTwo.SetActive(false);
                    anim = spaceShips[1].GetComponent<Animation>();
                    anim.Play("SShipMedLeave");
                }
                else if(missionSixH)
                {
                    hardEndTwo.SetActive(true);
                    manager.StartTimer();
                    hardMissionTwo.SetActive(false);
                    anim = spaceShips[2].GetComponent<Animation>();
                    anim.Play("SShipHardLeaveAnim");
                }
                ClosePanelB();
            }
            if(Input.GetKeyDown(KeyCode.C))
            {
                ClosePanelB();
            }
        }
        else if(endMissionpanel)
        {
            if((missionEndPromptOne.activeSelf || missionEndPromptTwo.activeSelf
                    || missionEndPromptThree.activeSelf || missionEndPromptFour.activeSelf
                    || missionEndPromptFive.activeSelf || missionEndPromptSix.activeSelf) 
                    && Input.GetKeyDown(KeyCode.C))
            {
                activeMission = false;
                if(missionOneE)
                {
                    manager.totalScore += 200;
                    anim = stationHatch.GetComponent<Animation>();
                    anim.Play("SStationPRelease");
                }
                else if(missionTwoM)
                {
                    manager.totalScore += 300;
                    anim = stationHatch.GetComponent<Animation>();
                    anim.Play("SStationPRelease");
                }
                else if(missionThreeH)
                {
                    manager.totalScore += 400;
                    
                }
                else if(missionFourE)
                {
                    manager.totalScore += 200;
                    anim = spaceShips[1].GetComponent<Animation>();
                    anim.Play("SShipMedArrive");
                }
                else if(missionFiveM)
                {
                    manager.totalScore += 300;
                    anim = spaceShips[2].GetComponent<Animation>();
                    anim.Play("SShipHardArrive");
                }
                else if(missionSixH)
                {
                    manager.totalScore += 400;
                }
                ClosePanelE();
                if(missionOneE == false && missionTwoM == false && missionThreeH == false && 
                    missionFourE == false && missionFiveM == false && missionSixH == false)
                {
                    win.SetActive(true);
                    player.GetComponent<CameraController>().DisableMovement();
                    player.GetComponent<PlayerController>().DisableMovement();
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Time.timeScale = 0f;
                    finalScore = manager.totalScore;
                    scoreText.text = finalScore.ToString();
                }
            }
        }
    }
    // plays both animation and sound
    public void OpenPanelEasy()
    {
        if(!activeMission)
        {
            if(missionOneE)
            {
                StationAduio.clip = hatchSound;
                StationAduio.Play();
                missionOneprompt.SetActive(true);
                acceptMissionPanel = true;
                PauseGame();
                //anim = stationHatch.GetComponent<Animation>();
                //anim.Play("SStationPRelease");
            }
            else if(missionFourE)
            {
                anim = SSHatches[0].GetComponent<Animation>();
                anim.Play("SShipPRelease");
                SpaceShip1.clip = hatchSound;
                SpaceShip1.Play();
                missionFourprompt.SetActive(true);
                acceptMissionPanel = true;
                PauseGame();
            }
        }
    }
    public void OpenPanelMedium()
    {
        if(!activeMission)
        {
            if(missionTwoM)
            {
                //anim = stationHatch.GetComponent<Animation>();
                //anim.Play("SStationPRelease");
                StationAduio.clip = hatchSound;
                StationAduio.Play();
                missionTwoprompt.SetActive(true);
                acceptMissionPanel = true;
                PauseGame();
            }
            else if(missionFiveM)
            {
                anim = SSHatches[1].GetComponent<Animation>();
                anim.Play("SShipPRelease");
                SpaceShip2.clip = hatchSound;
                SpaceShip2.Play();
                missionFiveprompt.SetActive(true);
                acceptMissionPanel = true;
                PauseGame();
            }
        }
    }
    public void OpenPanelHard()
    {
        if(!activeMission)
        {
            if(missionThreeH)
            {
                anim = stationHatch.GetComponent<Animation>();
                anim.Play("SStationPRelease");
                StationAduio.clip = hatchSound;
                StationAduio.Play();
                missionThreeprompt.SetActive(true);
                acceptMissionPanel = true;
                PauseGame();
            }
            else if(missionSixH)
            {
                anim = SSHatches[2].GetComponent<Animation>();
                anim.Play("SShipPRelease");
                SpaceShip3.clip = hatchSound;
                SpaceShip3.Play();
                missionSixprompt.SetActive(true);
                acceptMissionPanel = true;
                PauseGame();
            }
        }
    }
    // plays both animation and sound
    public void OpenPanelE()
    {
        manager.EndTimer();
        if(endMissionpanel)
        {
            if(missionOneE)
            {
                anim = SSHatches[0].GetComponent<Animation>();
                anim.Play("SShipPRelease");
                SpaceShip1.clip = hatchSound;
                SpaceShip1.Play();
                missionEndPromptOne.SetActive(true);
                PauseGame();
            }
            else if(missionTwoM)
            {
                anim = SSHatches[1].GetComponent<Animation>();
                anim.Play("SShipPRelease");
                SpaceShip2.clip = hatchSound;
                SpaceShip2.Play();
                missionEndPromptTwo.SetActive(true);
                PauseGame();
            }
            else if(missionThreeH)
            {
                anim = SSHatches[2].GetComponent<Animation>();
                anim.Play("SShipPRelease");
                SpaceShip3.clip = hatchSound;
                SpaceShip3.Play();
                missionEndPromptThree.SetActive(true);
                PauseGame();
            }
            else if(missionFourE)
            {
                anim = stationHatch.GetComponent<Animation>();
                anim.Play("SStationPRelease");
                StationAduio.clip = hatchSound;
                StationAduio.Play();
                missionEndPromptFour.SetActive(true);
                PauseGame();
            }
            else if(missionFiveM)
            {
                anim = stationHatch.GetComponent<Animation>();
                anim.Play("SStationPRelease");
                StationAduio.clip = hatchSound;
                StationAduio.Play();
                missionEndPromptFive.SetActive(true);
                PauseGame();
            }
            else if(missionSixH)
            {
                anim = stationHatch.GetComponent<Animation>();
                anim.Play("SStationPRelease");
                StationAduio.clip = hatchSound;
                StationAduio.Play();
                missionEndPromptSix.SetActive(true);
                PauseGame();
            }
        }
    }
    // Close panel begin play sounds from each place
    // Mission 1 will play ship flyin in anim
    // Missions 2 and 3 will play ships flying in from the random generator
    // Missions 4, 5 and 6 will play the hatch closing anim on ships
    public void ClosePanelB()
    {
        if(missionOneE)
        {
            StationAduio.clip = hatchSound;
            StationAduio.Play();
            missionOneprompt.SetActive(false);
            acceptMissionPanel = false;
            ResumeGame();
            anim = spaceShips[0].GetComponent<Animation>();
            anim.Play("SShipEasyArrive");
        }
        else if(missionTwoM)
        {
            StationAduio.clip = hatchSound;
            StationAduio.Play();
            missionTwoprompt.SetActive(false);
            acceptMissionPanel = false;
            ResumeGame();
            anim = spaceShips[1].GetComponent<Animation>();
            anim.Play("SShipMedArrive");
        }
        else if(missionThreeH)
        {
            StationAduio.clip = hatchSound;
            StationAduio.Play();
            missionThreeprompt.SetActive(false);
            acceptMissionPanel = false;
            ResumeGame();
            anim = spaceShips[2].GetComponent<Animation>();
            anim.Play("SShipHardArrive");
        }
        else if(missionFourE)
        {
            SpaceShip1.clip = hatchSound;
            SpaceShip1.Play();
            missionFourprompt.SetActive(false);
            acceptMissionPanel = false;
            ResumeGame();
            anim = SSHatches[0].GetComponent<Animation>();
            anim.Play("SShipEasyClose");
        }
        else if(missionFiveM)
        {
            SpaceShip2.clip = hatchSound;
            SpaceShip2.Play();
            missionFiveprompt.SetActive(false);
            acceptMissionPanel = false;
            ResumeGame();
            anim = SSHatches[1].GetComponent<Animation>();
            anim.Play("SShipMedClose");
        }
        else if(missionSixH)
        {
            SpaceShip3.clip = hatchSound;
            SpaceShip3.Play();
            missionSixprompt.SetActive(false);
            acceptMissionPanel = false;
            ResumeGame();
            anim = SSHatches[2].GetComponent<Animation>();
            anim.Play("SShipHardPClose");
        }
    }
    // close animations and sounds
    // need to be able to have the ships from missions 1,2,3 fly away as well
    public void ClosePanelE()
    {
        if(missionOneE)
        {
            SpaceShip1.clip = hatchSound;
            SpaceShip1.Play();
            missionEndPromptOne.SetActive(false);
            endMissionpanel = false;
            ResumeGame();
            anim2 = spaceShips[0].GetComponent<Animation>();
            anim2.Play("SShipEasyLeave");
            medMission.SetActive(true);
            missionOneE = false;
            missionTwoM = true;
        }
        else if(missionTwoM)
        {
            SpaceShip2.clip = hatchSound;
            SpaceShip2.Play();
            missionEndPromptTwo.SetActive(false);
            endMissionpanel = false;
            ResumeGame();
            anim2 = spaceShips[1].GetComponent<Animation>();
            anim2.Play("SShipMedLeave");
            hardMission.SetActive(true);
            missionTwoM = false;
            missionThreeH = true;
        }
        else if(missionThreeH)
        {
            SpaceShip3.clip = hatchSound;
            SpaceShip3.Play();
            missionEndPromptThree.SetActive(false);
            endMissionpanel = false;
            ResumeGame();
            anim = spaceShips[2].GetComponent<Animation>();
            anim.Play("SShipHardLeaveAnim");
            anim2 = spaceShips[0].GetComponent<Animation>();
            anim2.Play("SShipEasyArrive");
            missionThreeH = false;
            missionFourE = true;
            spaceShips[0].tag = "MissionEasy";
        }
        else if(missionFourE)
        {
            StationAduio.clip = hatchSound;
            StationAduio.Play();
            missionEndPromptFour.SetActive(false);
            endMissionpanel = false;
            ResumeGame();
            anim = stationHatch.GetComponent<Animation>();
            anim.Play("SStationPClose");
            missionFourE = false;
            missionFiveM = true;
            spaceShips[1].tag = "MissionMedium";
        }
        else if(missionFiveM)
        {
            StationAduio.clip = hatchSound;
            StationAduio.Play();
            missionEndPromptFive.SetActive(false);
            endMissionpanel = false;
            ResumeGame();
            anim = stationHatch.GetComponent<Animation>();
            anim.Play("SStationPClose");
            missionFiveM = false;
            missionSixH = true;
            spaceShips[2].tag = "MissionHard";
        }
        else if(missionSixH)
        {
            StationAduio.clip = hatchSound;
            StationAduio.Play();
            missionEndPromptSix.SetActive(false);
            endMissionpanel = false;
            ResumeGame();
            anim = stationHatch.GetComponent<Animation>();
            anim.Play("SStationPClose");
            missionSixH = false;
            // game over
        }
    }
    public void MissionRestart()
    {
        if(missionOneE)
        {
            missionOneE = true;
            easyMission.SetActive(true);
            activeMission = false;
            manager.totalScore -= 100;
            anim = stationHatch.GetComponent<Animation>();
            anim.Play("SStationPRelease");
            anim = spaceShips[0].GetComponent<Animation>();
            anim.Play("SShipEasyLeave");
        }
        else if(missionTwoM)
        {
            missionTwoM = true;
            medMission.SetActive(true);
            activeMission = false;
            manager.totalScore -= 150;
            anim = stationHatch.GetComponent<Animation>();
            anim.Play("SStationPRelease");
            anim = spaceShips[1].GetComponent<Animation>();
            anim.Play("SShipMedLeave");
        }
        else if(missionThreeH)
        {
            missionThreeH = true;
            hardMission.SetActive(true);
            activeMission = false;
            manager.totalScore -= 200;
            anim = stationHatch.GetComponent<Animation>();
            anim.Play("SStationPRelease");
            anim = spaceShips[2].GetComponent<Animation>();
            anim.Play("SShipHardLeaveAnim");
        }
        else if(missionFourE)
        {
            missionFourE = true;
            easyMissionTwo.SetActive(true);
            activeMission = false;
            manager.totalScore -= 100;
            anim2 = spaceShips[0].GetComponent<Animation>();
            anim2.Play("SShipEasyArrive");
            anim = SSHatches[0].GetComponent<Animation>();
            anim.Play("SShipPRelease");
        }
        else if(missionFiveM)
        {
            missionFiveM = true;
            medMissionTwo.SetActive(true);
            activeMission = false;
            manager.totalScore -= 150;
            anim2 = spaceShips[1].GetComponent<Animation>();
            anim2.Play("SShipMedArrive");
            anim = SSHatches[1].GetComponent<Animation>();
            anim.Play("SShipPRelease");
        }
        else if(missionSixH)
        {
            missionSixH = true;
            hardMissionTwo.SetActive(true);
            activeMission = false;
            manager.totalScore -= 200;
            anim2 = spaceShips[2].GetComponent<Animation>();
            anim2.Play("SShipHardArrive");
            anim = SSHatches[2].GetComponent<Animation>();
            anim.Play("SShipPRelease");
        } 
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
    }
     
    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public GameObject GetCurrentEndMission()
    {
        if (missionOneE)
            return easyEnd;
        else if (missionTwoM)
            return medEnd;
        else if (missionThreeH)
            return hardEnd;
        else if (missionFourE)
            return easyEndTwo;
        else if (missionFiveM)
            return medEndTwo;
        else if (missionSixH)
            return hardEndTwo;

        return null;
    }
}
