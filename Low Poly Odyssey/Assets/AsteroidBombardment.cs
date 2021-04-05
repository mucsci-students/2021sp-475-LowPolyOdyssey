using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBombardment : MonoBehaviour
{
    public GameObject forceField;
    public GameObject[] asteroids;
    public GameObject puzzleManager;
    [SerializeField] private AudioClip intenseMusic;
    /*[SerializeField] private AudioClip forceFieldStartUp;*/
    private AudioSource m_AudioSource;

    public GameObject asteroidWarning;


    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.time = 50.0f;
        InvokeRepeating("bombard", 140, 140);   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")){
            asteroidWarning.SetActive(false);
        }

        /*if(forceField.activeSelf){
            m_AudioSource.clip = forceFieldStartUp;
            m_AudioSource.Play();
        }*/
        if(m_AudioSource.time > 50.1f){
            asteroids[0].SetActive(false);
            asteroids[1].SetActive(false);
            asteroids[2].SetActive(false);
            forceField.SetActive(false);
            m_AudioSource.Stop();
            asteroidWarning.SetActive(false);
            puzzleManager.GetComponent<PuzzleManager>().ActivatePuzzle();
        }
    }

    void bombard(){
        //asteroids[Random.Range(0, asteroids.Length)].SetActive(true);
        asteroids[0].SetActive(true);
        asteroids[1].SetActive(true);
        asteroids[2].SetActive(true);
        m_AudioSource.clip = intenseMusic;
        m_AudioSource.Play();
        asteroidWarning.SetActive(true);
    }
}
