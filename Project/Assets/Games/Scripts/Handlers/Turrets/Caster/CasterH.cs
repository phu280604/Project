using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CasterH : MonoBehaviour
{
    #region --- Method ---

    #region -- Set up stats --
    private void StatsSetUp()
    {
        statsH.StatsCaster();
        fireDelay = 0;
    }
    #endregion

    private void Awake()
    {
        StatsSetUp();
    }

    #region -- Checking enemy in range --
    private void EnemiesChecker()
    {
        foreach (KeyValuePair<GameObject, bool> enemy in eCommands.Enemies)
        {
            if (enemy.Value)
            {
                float distance = ((Vector2)(transform.position - enemy.Key.transform.position)).magnitude;
                if (distance <= statsH.AtkRange)
                {
                    this.enemy = enemy.Key;
                    break;
                }
            }
        }
    }
    #endregion

    #region -- Shoot --
    private void Shoot()
    {
        float distance = ((Vector2)(transform.position - enemy.transform.position)).magnitude;
        if (distance <= statsH.AtkRange && fireDelay == 0)
            shoot.Shoot(transform.position, enemy);

        if (distance > statsH.AtkRange)
        {
            enemy = null;
            shoot.Shoot(transform.position, enemy);
        }
    }
    #endregion

    #region -- Delay timer --
    private void DelayTimer()
    {
        if (fireDelay <= statsH.AtkDelay)
            fireDelay += Time.deltaTime;
        else
            fireDelay = 0;
    }
    #endregion

    #region -- Rotation turrets --
    private void RotationTurrets()
    {
        rotationH.Rotation(enemy);
    }
    #endregion

    private void Update()
    {
        if (!gameCommands.PauseTime)
        {
            if (status.IsPlacing)
            {
                if (enemy != null)
                {
                    RotationTurrets();
                    Shoot();
                    DelayTimer();
                }
                else
                {
                    EnemiesChecker();
                    fireDelay = 0;
                }
            }
        }
    }

    #endregion

    #region --- Field ---

    [Header("Game manager components")]
    [SerializeField] private GameManagerCommands gameCommands;

    [Header("Turrets components")]
    [SerializeField] private StatusH status;
    [SerializeField] private ShootH shoot;
    [SerializeField] private RotationTurretsH rotationH;
    [SerializeField] private StatsTurrets statsH;

    [Header("Enemy components")]
    [SerializeField] private EnemiesCommands eCommands;
    [SerializeField] private GameObject enemy = null;

    [Header("Values")]
    [SerializeField] private float fireDelay;

    #endregion
}
