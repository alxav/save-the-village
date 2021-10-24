using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Setting", menuName = "Сustom Settings/New Enemy Setting", order = 1)]

public class EnemySetting : ScriptableObject
{
    [SerializeField] private EnemyData enemyData;

    public EnemyData EnemyData
    {
        get => enemyData;
    }
}


[Serializable]
public class EnemyData
{
    
    [Header("Время между нападениями на деревню")]
    [SerializeField] private int timeoutAttack;
    
    [Header("Количество врагов в одной волне (начальное значение)")]
    [SerializeField] private int countEnemy;
    
    [Header("Коэффициент увеличение врагов (через сколько волн идет увеличение врагов)")]
    [SerializeField] private int rationEnemy;

    [Header("До какого цикла врагов не будет")]
    [SerializeField] private int countCycle;


    public int TimeoutAttack => timeoutAttack;
    public int CountEnemy => countEnemy;
    public int RationEnemy => rationEnemy;
    public int CountCycle => countCycle;
}