using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Win Setting", menuName = "Сustom Settings/New Win Setting", order = 1)]
public class WinSetting : ScriptableObject
{
    [SerializeField] private WinData winData;

    public WinData WinData
    {
        get => winData;
    }
}


[Serializable]
public class WinData
{
    [Header("Количество крестьян для победы")] [SerializeField]
    public int countFarmer;

    [Header("Количество зерна для победы")] [SerializeField]
    public int countWheat;
    
}