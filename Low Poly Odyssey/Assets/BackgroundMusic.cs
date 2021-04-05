using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    private AudioSource m_AudioSource;
    [SerializeField] public AudioClip[] music;

    public GameObject asteroids1;
    public GameObject asteroids2;
    public GameObject asteroids3;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_AudioSource.isPlaying && !asteroids1.activeSelf 
            && !asteroids2.activeSelf && !asteroids3.activeSelf){
            playRandom();
        }
        if(asteroids1.activeSelf || asteroids2.activeSelf || asteroids3.activeSelf){
            m_AudioSource.Stop();
        }
    }

    void playRandom(){
        m_AudioSource.clip = music[Random.Range(0, music.Length)];
        m_AudioSource.Play();
    }
}
