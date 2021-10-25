using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;
    public static event Action<int> CountCycle;
    public static event Action<float> ProgressCycle;
    
    [SerializeField] private EnemySetting enemySetting;

    private EnemyData enemyData;
    private int countCycle;
    private float time;
    private Helpers helpers;
    private Coroutine CoroutineTimeoutCycle;
    private Warrior warrior;
    
    void Awake()
    {
        Instance = this;
        enemyData = enemySetting.EnemyData;
    }

    void Start()
    {
        helpers = new Helpers();
        countCycle = 0;
        warrior = Warrior.Instance;
        SetCount();
    }

    
    private IEnumerator TimeoutCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(0f);
            if (time > 0)
            {
                time -= Time.deltaTime;
                ProgressCycle?.Invoke(time / enemyData.TimeoutAttack);
            }
            else
            {
                Attack();
                break;
            }
        }
    }
    
    private void SetCount()
    {
        time = enemyData.TimeoutAttack;
        countCycle += 1;
        CountCycle?.Invoke(countCycle);

        if (CoroutineTimeoutCycle != null)
            StopCoroutine(CoroutineTimeoutCycle);
        
        CoroutineTimeoutCycle =  StartCoroutine(TimeoutCycle());
    }

    public EnemyData GetEnemyData() => enemyData;
    public int GetCountCycle() => countCycle;
    
    private void Attack()
    {
        time = enemyData.TimeoutAttack;
        var killWarrior = helpers.CountEnemyForCycle(countCycle, EnumCycle.Current, enemyData.CountCycle,
            enemyData.RationEnemy);
        warrior.SetCount(-killWarrior);
        
        // Защита, чтобы не увеличилось количество волн. Нужно было бы подвязаться к EnumStateGame, было бы красивее и вернее.
        if (warrior.GetCount() < 0)
            return;
        
        SetCount();
    }

    private void OnDestroy()
    {
        CountCycle = null;
        ProgressCycle = null;
    }
}
