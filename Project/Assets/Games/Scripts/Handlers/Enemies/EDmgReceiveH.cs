using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDmgReceiverH : MonoBehaviour
{
    #region --- Method ---

    #region -- Enemies dmg receive --
    public void EDmgRecerver(float dmg)
    {
        float dmgDeal = (dmg - stats.Def);
        if (dmgDeal <= 0)
            stats.Hp -= 1;
        else if (dmgDeal > 0)
            stats.Hp -= dmgDeal;
        
        aniCommands.ChangeAnimation("Hitting");
        status.IsMoving = false;

        if (!status.IsAttacking)
            Invoke("ResetMovingAnimation", 0.5f);
        else
            Invoke("ResetAttackingAnimation", 0.5f);
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
    }
    #endregion

    #region -- Dead --
    private void Dead()
    {
        commands.Enemies[objParent] = false;
        commands.EnemiesCount += 1;

        aniCommands.ChangeAnimation("Dying");
        
        status.IsMoving = false;
        status.IsAttacking = false;
        status.IsDying = true;
        
        Invoke("Destroy", 2f);
    }

    private void Destroy()
    {
        objParent.SetActive(false);
    }
    #endregion

    private void Update()
    {
        if (stats.Hp <= 0) Dead();
    }

    #endregion

    #region --- Field ---

    [SerializeField] private EStatus status;
    [SerializeField] private StatsEnemies stats;
    [SerializeField] private EnemiesCommands commands;
    [SerializeField] private AnimationCommand aniCommands;

    [SerializeField] private GameObject objParent;

    #endregion
}
