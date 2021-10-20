using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Setting", menuName = "Сustom Settings/New Enemy Setting", order = 1)]

public class EnemySetting : ScriptableObject
{
    [SerializeField] private Enemy enemy;

    public Enemy Enemy
    {
        get => enemy;
    }
}


[Serializable]
public class Enemy
{
    public string name;
    
    [Header("Время между нападениями на деревню")]
    [SerializeField] private int timeoutAttack;
    
    [Header("Количество врагов в одной волне")]
    [SerializeField] private int countEnemy;

}