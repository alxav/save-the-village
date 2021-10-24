using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public static Warrior Instance;
    public static event Action<float> ProgressTraining;
    public static event Action<int> Count;

    [SerializeField] private int startCount;
    [SerializeField] private WarriorSetting warriorSetting;
    
    private WarriorData warriorData;
    private int count;
    private float time;

    private void Awake()
    {
        Instance = this;
        warriorData = warriorSetting.Warrior;
    }

    private void Start()
    {
        SetCount(startCount);
    }

    private IEnumerator TimeoutTraining()
    {
        while (true)
        {
            yield return new WaitForSeconds(0f);
            if (time < warriorData.TimeTraining)
            {
                time += Time.deltaTime;
                ProgressTraining?.Invoke(new Helpers().GetPercentProgress(time, warriorData.TimeTraining));
            }
            else
            {
                time = 0;
                SetCount(1);
                yield break;
            }
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        Count = null;
        ProgressTraining = null;
    }
    
    public int GetCont() => count;

    public WarriorData GetWarriorData() => warriorData; 

    public void SetCount(int value)
    {
        count += value;
        Count?.Invoke(count);
    }

    public void Training()
    {
        time = 0;
        Wheat.Instance.SetCount(-warriorData.PriceInWheat);
        StartCoroutine(TimeoutTraining());
    }
    
    
    
}
