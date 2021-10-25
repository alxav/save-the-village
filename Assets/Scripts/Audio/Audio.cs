using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
    [SerializeField] private AudioClip audioGame;
    [SerializeField] private AudioClip audioWin;
    [SerializeField] private AudioClip audioDefeat;

    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameManager.State += SetAudio;
    }

    private void SetAudio(EnumStateGame state)
    {
        switch (state)
        {
            case EnumStateGame.Lobby:
                UpdateAudio(audioGame, true);
                break;
            case EnumStateGame.Win:
                UpdateAudio(audioWin, false);
                break;
            case EnumStateGame.Defeat:
                UpdateAudio(audioDefeat, false);
                break;
            case EnumStateGame.Pause:
                audioSource.Pause();
                break;
            case EnumStateGame.Game:
                audioSource.Play();
                break;
        }        
    }

    private void UpdateAudio(AudioClip clip, bool isLoop)
    {
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.loop = isLoop;
    }

}
