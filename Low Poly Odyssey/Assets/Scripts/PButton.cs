using UnityEngine;

public class PButton : MonoBehaviour
{
    public PLight[] lights;
    
    AudioSource[] sources;

    void Start()
    {
        sources = GetComponents<AudioSource>();
    }

    public void ToggleLights()
    {
        foreach (PLight l in lights)
        {
            l.Toggle();
        }
    }

    public void PlaySound()
    {
        int soundNum = Random.Range(0, sources.Length);
        sources[soundNum].Play();
    }
}