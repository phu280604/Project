using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SniperH : MonoBehaviour
{
    #region --- Method ---

    #region -- Set up stats --
    private void StatsSetUp()
    {
        switch (layer)
        {
            case int n when n == LayerMask.GetMask("SniperTur"):
                statsH.StatsSniper();
                fireDelay = 0;
                break;
        }
    }
    #endregion

    private void Start()
    {
        StatsSetUp();
    }

    #region -- Checking and Shoot --
    private void EnemiesChecker()
    {
        float distance = 0;
        if (enemy == null)
        {
            foreach (GameObject enemies in eCommands.Enemies)
            {
                distance = ((Vector2)(transform.position - enemies.transform.position)).magnitude;
                if (distance <= statsH.AtkRange)
                {
                    enemy = enemies;
                    break;
                }
            }
        }
        else
        {
            distance = ((Vector2)(transform.position - enemy.transform.position)).magnitude;
            if (distance <= statsH.AtkRange && fireDelay == 0)
            {
                shoot.Shoot(transform.position, enemy.transform.position);
                DelayTimer();
            }
            else if (distance > statsH.AtkRange)
                enemy = null;
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
        EnemiesChecker();
        if (enemy != null) RotationTurrets();
    }

    #endregion

    #region --- Field ---

    [Header("Layer")]
    [SerializeField] LayerMask layer;

    [Header("Turrets component")]
    [SerializeField] private ShootH shoot;
    [SerializeField] private RotationTurretsH rotationH;
    [SerializeField] private StatsTurrets statsH;

    [Header("Enemy component")]
    [SerializeField] private EnemiesCommands eCommands;
    [SerializeField] private GameObject enemy = null;

    [Header("Value")]
    [SerializeField] private float fireDelay;

    #endregion
}
