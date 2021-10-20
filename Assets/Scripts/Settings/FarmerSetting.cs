using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Farmer Setting", menuName = "Сustom Settings/New Farmer Setting", order = 1)]

public class FarmerSetting : ScriptableObject
{
    [SerializeField] private Farmer farmer;

    public Farmer Farmer
    {
        get => farmer;
    }
}


[Serializable]
public class Farmer
{
    public string name;

    [Header("Количество пшеницы, которое добывает 1 крестьянин за цикл:")]
    [SerializeField] private int extractCountWheat;
    
    [Header("Цикл добывания крестьянами пшеницы (сек.):")]
    [SerializeField] private int timeoutExtract;
    
    [Header("Стоимость найма одного крестьянина (в пшеницах):")]
    [SerializeField] private int priceInWheat;
    
    [Header("Время найма одного крестьянина (сек.):")]
    [SerializeField] private int timeTraining;
    
    

}