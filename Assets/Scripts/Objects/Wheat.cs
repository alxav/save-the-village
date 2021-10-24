
using System;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    [SerializeField] private int startCount;
    public static Wheat Instance;
    public static event Action<int> Count;

    private int count;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetCount(startCount);
    }


    public int GetCont() => count;

    public void SetCount(int value)
    {
        count += value;

        if (count < 0) count = 0;
        
        Count?.Invoke(count);
    }

    private void OnDestroy()
    {
        Count = null;
    }
}
