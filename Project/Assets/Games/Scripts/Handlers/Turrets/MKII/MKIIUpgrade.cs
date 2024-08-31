using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MKIIUpgrade : MonoBehaviour, IUpgrade
{
    private void Start()
    {
        if (this.gameObject != null)
        {
            gameCommands = GameObject.FindWithTag("GameController").GetComponent<GameManagerCommands>();
            casterTurrets = this.gameObject;
            status = this.gameObject.GetComponent<StatusH>();
            statsTurrets = casterTurrets.GetComponent<StatsTurrets>();
        }
    }

    public void UpgradeLvl2()
    {
        gameCommands.Cost -= statsTurrets.CostUpgrade;

        statsTurrets.Lvl += 1;
        statsTurrets.CostUpgrade += 2;

        statsTurrets.MaxHP += (int)(statsTurrets.MaxHP * 20 / 100);
        statsTurrets.Hp = statsTurrets.MaxHP;

        statsTurrets.Def += (int)(statsTurrets.Def * 15 / 100);

        statsTurrets.Atk += (int)(statsTurrets.Atk * 15 / 100);

        statsTurrets.AtkRange += 0.2f;
        statsTurrets.AtkDelay += 0.3f;
    }
    public void UpgradeLvl3()
    {
        gameCommands.Cost -= statsTurrets.CostUpgrade;

        statsTurrets.Lvl += 1;
        statsTurrets.CostUpgrade += 2;

        statsTurrets.MaxHP += (int)(statsTurrets.MaxHP * 20 / 100);
        statsTurrets.Hp = statsTurrets.MaxHP;

        statsTurrets.Def += (int)(statsTurrets.Def * 15 / 100);

        statsTurrets.Atk += (int)(statsTurrets.Atk * 15 / 100);

        statsTurrets.AtkRange += 0.2f;
        statsTurrets.AtkDelay += 0.3f;
    }
    public void UpgradeLvl4()
    {
        gameCommands.Cost -= statsTurrets.CostUpgrade;

        statsTurrets.Lvl += 1;
        statsTurrets.CostUpgrade += 2;

        statsTurrets.MaxHP += (int)(statsTurrets.MaxHP * 20 / 100);
        statsTurrets.Hp = statsTurrets.MaxHP;

        statsTurrets.Def += (int)(statsTurrets.Def * 15 / 100);

        statsTurrets.Atk += (int)(statsTurrets.Atk * 15 / 100);

        statsTurrets.AtkRange += 0.2f;
        statsTurrets.AtkDelay += 0.3f;
    }
    public void UpgradeLvl5()
    {
        gameCommands.Cost -= statsTurrets.CostUpgrade;

        statsTurrets.Lvl += 1;
        statsTurrets.CostUpgrade += 2;

        statsTurrets.MaxHP += (int)(statsTurrets.MaxHP * 20 / 100);
        statsTurrets.Hp = statsTurrets.MaxHP;

        statsTurrets.Def += (int)(statsTurrets.Def * 15 / 100);

        statsTurrets.Atk += (int)(statsTurrets.Atk * 15 / 100);

        statsTurrets.AtkRange += 0.2f;
        statsTurrets.AtkDelay += 0.3f;
    }

    #region --- Field ---

    private GameManagerCommands gameCommands;
    private GameObject casterTurrets;
    private StatsTurrets statsTurrets;
    private AnimationCommand animator;
    private StatusH status;

    #endregion
}
