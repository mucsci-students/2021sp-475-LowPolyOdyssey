using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playWarningSound : MonoBehaviour
{
    private AudioSource aud;
    public GameObject warningPrompt;
    public AudioClip warningSound;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(warningPrompt.activeSelf){
            if(!aud.isPlaying){
                aud.PlayOneShot(warningSound);
            }
        }
    }
}
