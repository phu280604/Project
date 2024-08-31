using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankH : MonoBehaviour
{
    #region --- Method ---

    #region -- Set up stats --
    private void StatsSetUp()
    {
        stats = this.gameObject.GetComponent<StatsTurrets>();
        stats.StatsTank();
        fireDelay = 0;
    }
    #endregion

    #region -- Set up component --
    private void SetComponent()
    {
        // Game manager commands.
        gameCommands = GameObject.FindWithTag("GameController").GetComponent<GameManagerCommands>();

        // Enemy commands.
        enemyCommands = GameObject.Find("Enemies").GetComponent<EnemiesCommands>();

        // Status turret.
        status = this.gameObject.GetComponent<StatusH>();
    }
    #endregion

    private void Awake()
    {
        if (this.gameObject != null && this.gameObject.activeSelf)
        {
            StatsSetUp();
            SetComponent();

            fireDelay = 0;
            enemy = null;
        }
    }

    #region -- Checking enemy in range --
    private void EnemiesChecker()
    {
        foreach (KeyValuePair<GameObject, bool> enemy in enemyCommands.Enemies)
        {
            if (enemy.Value)
            {
                float distance = ((Vector2)(transform.position - enemy.Key.transform.position)).magnitude;
                if (distance < stats.AtkRange)
                {
                    this.enemy = enemy.Key;
                    status.IsAttacking = true;
                    break;
                }
                else
                {
                    this.enemy = null;
                }
            }
        }
    }
    #endregion

    #region -- Shoot --
    private void Shoot()
    {
        float distance = ((Vector2)(transform.position - enemy.transform.position)).magnitude;
        if (distance < stats.AtkRange && fireDelay == 0 && enemy != null)
        {
            AnimationCommand animator = gameObject.GetComponent<AnimationCommand>();
            animator.ChangeAnimation("Attacking");
            animator.SetSpeed(stats.AtkDelay + 0.5f);
            shoot.Shoot(gameObject.transform.position, enemy);
        }

        if (distance > stats.AtkRange && enemy != null)
        {
            AnimationCommand animator = gameObject.GetComponent<AnimationCommand>();
            animator.ChangeAnimation("Idle");
            animator.SetSpeed(1f);
            enemy = null;
            shoot.Shoot(gameObject.transform.position, enemy);
        }
    }
    #endregion

    #region -- Delay timer --
    private void DelayTimer()
    {
        if (fireDelay <= stats.AtkDelay)
            fireDelay += Time.deltaTime;
        else
            fireDelay = 0;
    }
    #endregion

    #region -- Rotation turrets --
    private void RotationTurrets()
    {
        rotationBarrel.Rotation(enemy);
    }
    #endregion

    #region -- Attacking handle --
    private void AttackingH()
    {
        if (enemy != null)
        {
            RotationTurrets();
            Shoot();
            DelayTimer();
        }
        else
            fireDelay = 0;
    }
    #endregion

    #region -- Upgrade handle --
    private void UpgradeH()
    {
        TankUpgrade upgrade = this.gameObject.GetComponent<TankUpgrade>();
        switch (stats.Lvl)
        {
            case 1:
                upgrade.UpgradeLvl2();
                break;

            case 2:
                upgrade.UpgradeLvl3();
                break;

            case 3:
                upgrade.UpgradeLvl4();
                break;

            case 4:
                upgrade.UpgradeLvl5();
                break;
        }
        effSprite.SetActive(true);
        status.IsUpgrade = false;
    }
    #endregion

    private void Update()
    {
        if (gameCommands.BuildingTime)
        {
            if (status.IsPlacing && status.IsUpgrade)
            {
                UpgradeH();
            }
        }

        if (!gameCommands.PauseTime)
        {

            if (enemy == null)
            {
                EnemiesChecker();
            }

            if (status.IsPlacing && status.IsAttacking)
            {
                AttackingH();
            }
        }
    }

    #endregion

    #region --- Field ---

    private GameManagerCommands gameCommands;

    private StatusH status;
    private StatsTurrets stats;
    [SerializeField] private RotationTurretsH rotationBarrel;
    [SerializeField] private ShootH shoot;

    private EnemiesCommands enemyCommands;

    [Header("Values")]
    [SerializeField] private GameObject effSprite;
    [SerializeField] private float fireDelay;
    private GameObject enemy;

    #endregion
}
