using UnityEngine;

public class CannonAudioScript : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCannonFired() 
    {
        audioSource.Play();
    }
}
