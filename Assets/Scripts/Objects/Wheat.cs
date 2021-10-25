using System;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    [SerializeField] private int startCount;
    public static Wheat Instance;
    public static event Action<int> Count;

    private int count;
    private int allCount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetCount(startCount);
    }
    
    private void OnDestroy()
    {
        Count = null;
    }
    
    public int GetCont() => count; 
    
    // Отнимаем стартовое значение, мы его не производили
    public int GetAllCont() => allCount - startCount;

    public void SetCount(int value)
    {
        count += value;

        if (value > 0)
            allCount += value;
        
        if (count < 0) count = 0;
        
        Count?.Invoke(count);
    }
}
