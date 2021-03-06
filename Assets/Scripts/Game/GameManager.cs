using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action<EnumStateGame> State;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetSate(EnumStateGame.Lobby);
    }

    public void StartGame()
    {
        SetSate(EnumStateGame.Game);
    }
    
    public void WinGame()
    {
        SetSate(EnumStateGame.Win);
    }
    
    public void DefeatGame()
    {
        SetSate(EnumStateGame.Defeat);
    }
    
    public void PauseGame()
    {
        SetSate(EnumStateGame.Pause);
    }

    private void SetSate(EnumStateGame state)
    {
        State?.Invoke(state);
    }

    private void OnDestroy()
    {
        State = null;
    }
}
