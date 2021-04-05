using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{

    public int forceFieldHealth = 5;
    public GameObject forceField;

    public GameObject asteroids1;
    public GameObject asteroids2;
    public GameObject asteroids3;

    [SerializeField] private AudioClip stationHit;

    private AudioSource f_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        f_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(forceFieldHealth == 0){
            forceField.SetActive(false);
        }
        if(asteroids1.activeSelf || asteroids2.activeSelf || asteroids3.activeSelf ){
            forceField.SetActive(true);
        }
    }

    void OnParticleCollision(GameObject other){
        Debug.Log(other.tag);
        if(other.CompareTag("Asteroid")){
            Debug.Log("collided");
            forceFieldHealth -= 1 ;
            f_AudioSource.clip = stationHit;
            f_AudioSource.Play();
        }
    }

}
