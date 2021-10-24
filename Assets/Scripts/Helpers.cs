using UnityEngine;

public class Helpers
{
    public float GetPercentProgress(float currentTime, float allTime)
    {
        return 1 - (currentTime / allTime);
    }

    public void SetTimeScale(float value)
    {
        Time.timeScale = value;
    }

    public int CountEnemyForCycle(int currentCycle, EnumCycle cycle, int countCycle, int rationEnemy)
    {
        if (cycle == EnumCycle.Next) currentCycle++;
        
        if (currentCycle <= countCycle) return 0;
        
        var count = currentCycle - countCycle;
        
        return Mathf.CeilToInt((float)count / (float)rationEnemy);

    }
}
