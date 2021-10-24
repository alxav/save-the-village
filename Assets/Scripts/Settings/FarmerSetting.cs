using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Farmer Setting", menuName = "Сustom Settings/New Farmer Setting", order = 1)]

public class FarmerSetting : ScriptableObject
{
    [SerializeField] private FarmerData farmer;

    public FarmerData Farmer
    {
        get => farmer;
    }
}


[Serializable]
public class FarmerData
{

    [Header("Количество пшеницы, которое добывает 1 крестьянин за цикл:")]
    [SerializeField] private int extractCountWheat;
    
    [Header("Цикл добывания крестьянами пшеницы (сек.):")]
    [SerializeField] private int timeoutExtract;
    
    [Header("Стоимость найма одного крестьянина (в пшеницах):")]
    [SerializeField] private int priceInWheat;
    
    [Header("Время найма одного крестьянина (сек.):")]
    [SerializeField] private int timeTraining;

    public int ExtractCountWheat => extractCountWheat;
    public int TimeoutExtract => timeoutExtract;
    public int PriceInWheat => priceInWheat;
    public int TimeTraining => timeTraining;
    
}