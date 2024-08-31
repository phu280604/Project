using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBarCtrl : MonoBehaviour
{
    private void Start()
    {
        if (gameCommands.Wave == 5 && gameCommands.StartTime)
        {
            foreach (var boss in enemiesCommands.Enemies)
            {
                if (boss.Value)
                {
                    this.boss = boss.Key;
                    bossName.text = this.boss.name.Replace("(Clone) #1", "");
                }
            }

            
        }
    }

    public void UpdateBossHealth(float hp, float maxHp)
    {
        bossHealthBar.value = hp / maxHp;
    }

    #region --- Field ---

    [SerializeField] private GameManagerCommands gameCommands;
    [SerializeField] private EnemiesCommands enemiesCommands;

    [SerializeField] private Slider bossHealthBar;
    [SerializeField] private TextMeshProUGUI bossName;
    private GameObject boss;

    #endregion
}
