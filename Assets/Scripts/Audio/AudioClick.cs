using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioClick : MonoBehaviour
{
    
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        audioSource.Play();
    }
}
