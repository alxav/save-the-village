using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Warrior Setting", menuName = "Сustom Settings/New Warrior Setting", order = 1)]

public class WarriorSetting : ScriptableObject
{
    [SerializeField] private Warrior warrior;

    public Warrior Warrior
    {
        get => warrior;
    }
}


[Serializable]
public class Warrior
{
    public string name;

    [Header("Количество пшеницы, которое потребляет 1 воин за цикл:")]
    [SerializeField] private int eatCountWheat;
    
    [Header("Цикл потребления воинами пшеницы (сек.):")]
    [SerializeField] private int timeoutEat;
    
    [Header("Стоимость найма одного воина (в пшеницах):")]
    [SerializeField] private int priceInWheat;
    
    [Header("Время найма одного воина (сек.):")]
    [SerializeField] private int timeTraining;
    
    

}