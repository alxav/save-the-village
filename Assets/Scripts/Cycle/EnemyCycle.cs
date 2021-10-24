using UnityEngine;
using UnityEngine.UI;

public class EnemyCycle : MonoBehaviour
{
    [SerializeField] private Text textCurrentEnemy;
    [SerializeField] private Text textNextEnemy;
    [SerializeField] private Image reload;

    private Helpers helpers;
    private EnemyData enemyData;

    void Start()
    {
        helpers = new Helpers();
        enemyData = Enemy.Instance.GetEnemyData();
        Enemy.CountCycle += UpdateCountEnemy;
        Enemy.ProgressCycle += UpdateReload;
    }

    private void UpdateReload(float value)
    {
        if (!reload) return;
        reload.fillAmount = value;
    }

    private void UpdateCountEnemy(int value)
    {   

        var currentEnemy = helpers.CountEnemyForCycle(value, EnumCycle.Current, enemyData.CountCycle,
            enemyData.RationEnemy);

        var nextEnemy = helpers.CountEnemyForCycle(value, EnumCycle.Next, enemyData.CountCycle,
            enemyData.RationEnemy);

        SetTextCount(textCurrentEnemy, currentEnemy);
        SetTextCount(textNextEnemy, nextEnemy);
    }

    private void SetTextCount(Text text, int count)
    {
        if (text)
            text.text = count.ToString();
    }
}