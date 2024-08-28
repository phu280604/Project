using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingH : MonoBehaviour
{
    #region --- Method ---
    private void Start()
    {
        delay = 0;
    }

    private void DelayAttacking()
    {
        if (delay <= stats.AtkDelay)
            delay += Time.deltaTime;
        else
            delay = 0;
    }

    private void DealDmg()
    {
        GameObject target = dmgSender.Block;
        if (target != null && target.tag != "EndPoint")
        {
            TDmgReceiverH targetReveive = target.GetComponent<TDmgReceiverH>();
            targetReveive.Receive(stats.Atk);
        }
        else if (target != null && target.tag == "EndPoint")
        {
            Debug.Log(gameCommands.HP);
            gameCommands.HP -= stats.Atk;
        }
    }

    private void Update()
    {
        if (status.IsAttacking)
        {
            if (delay == 0)
            {
                aniCommands.ChangeAnimation("Attacking");
                DealDmg();
            }
            DelayAttacking();
        }
        else
            delay = 0;
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameManagerCommands gameCommands;
    [SerializeField] private EStatus status;
    [SerializeField] private StatsEnemies stats;
    [SerializeField] private EDmgSenderH dmgSender;
    [SerializeField] private AnimationCommand aniCommands;
    private float delay;

    #endregion
}
