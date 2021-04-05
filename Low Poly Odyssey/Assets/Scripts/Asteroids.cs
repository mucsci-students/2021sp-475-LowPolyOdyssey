using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public int asteroidCount;
    public float speadAngle;
    public GameObject asteroidCluster;
    public float asteroidFireVel = 1;
    public Transform asteroidExit;
    List<Quaternion> asteroids;

    // Start is called before the first frame update
    void Start()
    {
        asteroids = new List<Quaternion>(asteroidCount);
        for(int i = 0; i < asteroidCount; i++){
            asteroids.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey("q")){
             fire();
         }
    }

    void fire(){
        int i = 0;
        foreach(Quaternion quat in asteroids){
            asteroids[i] = Random.rotation;
            GameObject a = Instantiate(asteroidCluster, asteroidExit.position, asteroidExit.rotation);
            a.transform.rotation = Quaternion.RotateTowards(a.transform.rotation, asteroids[i], speadAngle);
            a.GetComponent<Rigidbody>().AddForce(a.transform.right * asteroidFireVel);
            i++;
        }
    }

}
