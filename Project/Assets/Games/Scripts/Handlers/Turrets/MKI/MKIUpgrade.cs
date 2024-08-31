using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MKIUpgrade : MonoBehaviour, IUpgrade
{
    private void Start()
    {
        if (this.gameObject != null)
        {
            spriteAnimator.SetActive(true);
            if (spriteAnimator != null && spriteAnimator.activeSelf)
                animator = spriteAnimator.GetComponent<AnimationCommand>();
            gameCommands = GameObject.FindWithTag("GameController").GetComponent<GameManagerCommands>();
            casterTurrets = this.gameObject;
            status = this.gameObject.GetComponent<StatusH>();
            statsTurrets = casterTurrets.GetComponent<StatsTurrets>();
            spriteAnimator.SetActive(false);
        }
    }

    public void Update()
    {
        if (status.IsUpgrade)
        {
            spriteAnimator.SetActive(true);
            Animator effectedAni = spriteAnimator.GetComponent<Animator>();
            effectedAni.SetBool("isUpgrade", true);
            AnimatorStateInfo stateInfo = effectedAni.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Upgrade") && stateInfo.normalizedTime >= 1.0f)
            {
                effectedAni.SetBool("isUpgrade", false);
                spriteAnimator.SetActive(false);
            }
        }
    }

    public void UpgradeLvl2()
    {
        gameCommands.Cost -= statsTurrets.CostUpgrade;

        statsTurrets.Lvl += 1;
        statsTurrets.CostUpgrade += 1;

        statsTurrets.MaxHP += (int)(statsTurrets.MaxHP * 15 / 100);
        statsTurrets.Hp = statsTurrets.MaxHP;

        statsTurrets.Def += (int)(statsTurrets.Def * 15 / 100);

        statsTurrets.Atk += (int)(statsTurrets.Atk * 25 / 100);

        statsTurrets.AtkDelay -= 0.1f;
    }
    public void UpgradeLvl3()
    {
        gameCommands.Cost -= statsTurrets.CostUpgrade;

        statsTurrets.Lvl += 1;
        statsTurrets.CostUpgrade += 1;

        statsTurrets.MaxHP += (int)(statsTurrets.MaxHP * 15 / 100);
        statsTurrets.Hp = statsTurrets.MaxHP;

        statsTurrets.Def += (int)(statsTurrets.Def * 15 / 100);

        statsTurrets.Atk += (int)(statsTurrets.Atk * 25 / 100);

        statsTurrets.AtkDelay -= 0.1f;
    }
    public void UpgradeLvl4()
    {
        gameCommands.Cost -= statsTurrets.CostUpgrade;

        statsTurrets.Lvl += 1;
        statsTurrets.CostUpgrade += 1;

        statsTurrets.MaxHP += (int)(statsTurrets.MaxHP * 15 / 100);
        statsTurrets.Hp = statsTurrets.MaxHP;

        statsTurrets.Def += (int)(statsTurrets.Def * 15 / 100);

        statsTurrets.Atk += (int)(statsTurrets.Atk * 25 / 100);
    }
    public void UpgradeLvl5()
    {
        gameCommands.Cost -= statsTurrets.CostUpgrade;

        statsTurrets.Lvl += 1;
        statsTurrets.CostUpgrade = 0;

        statsTurrets.MaxHP += (int)(statsTurrets.MaxHP * 15 / 100);
        statsTurrets.Hp = statsTurrets.MaxHP;

        statsTurrets.Def += (int)(statsTurrets.Def * 15 / 100);

        statsTurrets.Atk += (int)(statsTurrets.Atk * 25 / 100);
    }

    #region --- Field ---

    [SerializeField] GameObject spriteAnimator;
    private GameManagerCommands gameCommands;
    private GameObject casterTurrets;
    private StatsTurrets statsTurrets;
    private AnimationCommand animator;
    private StatusH status;

    #endregion
}
