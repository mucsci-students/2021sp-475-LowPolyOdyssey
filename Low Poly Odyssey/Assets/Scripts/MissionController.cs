using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    public MissionManager prompt;
    public Transform player;
    // Distance package moves after being set active.
    public Vector3 activateDistance;

    float moveSpeed = 0.1f;
    
    float startTime;
    float totalDist;
    Vector3 oldPos, newPos;
    public bool isEndMission;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        oldPos = transform.position;
        newPos = oldPos + activateDistance;
        totalDist = Vector3.Distance(oldPos, newPos);
        startTime = Time.time;
    }
    void Update()
    {
        // transform.LookAt(player);
        // if((player.transform.position - this.transform.position).sqrMagnitude<4*4)
        // {
        //     transform.position += transform.forward * moveSpeed * Time.deltaTime;
        // }
        if(!isEndMission){
            float distCovered = (Time.time - startTime) * moveSpeed;
            float distFraction = distCovered / totalDist;
            transform.position = Vector3.Lerp(oldPos, newPos, distFraction);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MainCamera")
        {
            if(this.gameObject.tag == "MissionEasy")
            {
                prompt.OpenPanelEasy();
            }
            else if(this.gameObject.tag == "MissionMedium")
            {
                prompt.OpenPanelMedium();
            }
            else if(this.gameObject.tag == "MissionHard")
            {
                prompt.OpenPanelHard();
            }
            else if(this.gameObject.tag == "missionEnd")
            {
                prompt.OpenPanelE();
            }
        }
    }

}
