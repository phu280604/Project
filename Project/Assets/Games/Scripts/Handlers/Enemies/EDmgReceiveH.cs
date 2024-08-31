using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDmgReceiverH : MonoBehaviour
{
    #region --- Method ---

    #region -- Enemies dmg receive --
    public void EDmgRecerver(float dmg)
    {
        if (!status.IsDying)
        {
            float dmgDeal = (dmg - stats.Def);
            if (dmgDeal <= 0)
                stats.Hp -= 1;
            else if (dmgDeal > 0)
                stats.Hp -= dmgDeal;

            if (gameCommands.Wave != 5)
            {
                eHealthBar.UpdateHelthBar(stats.Hp, stats.MaxHP);
            }
            else
            {
                bHealthBar.UpdateBossHealth(stats.Hp, stats.MaxHP);
            }

            aniCommands.ChangeAnimation("Hitting");
            bool lastStatus = status.IsMoving;
            status.IsMoving = false;
            status.IsAttacking = false;

            if (lastStatus)
                Invoke("ResetMovingAnimation", 0.7f);
            else
                Invoke("ResetAttackingAnimation", 0.7f);
        }
    }
    #endregion

    #region -- Reset animation --
    private void ResetMovingAnimation()
    {
        aniCommands.ChangeAnimation("Running");
        status.IsMoving = true;
    }

    private void ResetAttackingAnimation()
    {
        aniCommands.ChangeAnimation("Attacking");
        status.IsAttacking = true;
    }
    #endregion

    #region -- Dead --
    private void Dead()
    {

        if (commands.Enemies.ContainsKey(objParent))
        {
            commands.Enemies[objParent] = false;
        }

        aniCommands.ChangeAnimation("Dying");

        status.IsMoving = false;
        status.IsAttacking = false;
        status.IsDying = true;

        Invoke("Destroy", 0.6f);
    }

    private void Destroy()
    {
        commands.EnemiesCount += 1;
        gameCommands.Cost += stats.CostDrop;
        objParent.SetActive(false);
        Destroy(objParent);
    }
    #endregion

    private void Update()
    {
        if (!gameCommands.PauseTime && !status.IsDying)
            if (stats.Hp <= 0) Dead();
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameManagerCommands gameCommands;
    [SerializeField] private EStatus status;
    [SerializeField] private StatsEnemies stats;
    [SerializeField] private EnemiesCommands commands;
    [SerializeField] private AnimationCommand aniCommands;

    [SerializeField] private GameObject objParent;

    [SerializeField] private EHealthBarCtrl eHealthBar;
    [SerializeField] private BossHealthBarCtrl bHealthBar;

    #endregion
}
