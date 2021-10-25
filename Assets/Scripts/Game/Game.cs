using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    
    private Helpers helpers;
    
    void Start()
    {
        helpers = new Helpers();
        GameManager.State += StateUpdate;
    }

    private void StateUpdate(EnumStateGame state)
    {
        switch (state)
        {
            case EnumStateGame.Lobby:
                uiManager.OpenStartPanel();
                helpers.SetTimeScale(0);
                break;
            case EnumStateGame.Game:
                uiManager.CloseStartPanel();
                helpers.SetTimeScale(1);
                break;
            case EnumStateGame.Defeat:
                uiManager.OpenDefeatPanel();
                helpers.SetTimeScale(0);
                break;
            case EnumStateGame.Win:
                uiManager.OpenWinPanel();
                helpers.SetTimeScale(0);
                break;

        }
        
    }

}
