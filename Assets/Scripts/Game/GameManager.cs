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

    private void SetSate(EnumStateGame state)
    {
        State?.Invoke(state);
    }

    private void OnDestroy()
    {
        State = null;
    }
}
