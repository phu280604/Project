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
            if (distance <= statsH.AtkRange && fireDelay == 0.1f)
            {

                shoot.Shoot(transform.position, enemy.transform.position);
            }
            else if (distance > statsH.AtkRange)
                enemy = null;
        }

        if (fireDelay <= statsH.AtkSpeed)
            fireDelay += 0.2f;
        else
            fireDelay = 0.1f;
    }
    #endregion

    #region -- Rotation turrets --
    private void RotationTurrets()
    {
        rotationH.Rotation(enemy.transform.position);
    }
    #endregion

    private void FixedUpdate()
    {
        EnemiesChecker();
        if (enemy != null) RotationTurrets();
    }

    #endregion

    #region --- Field ---

    [SerializeField] LayerMask layer;

    [SerializeField] private ShootH shoot;
    [SerializeField] private RotationTurretsH rotationH;
    [SerializeField] private StatsTurrets statsH;

    [SerializeField] private EnemiesCommands eCommands;

    [SerializeField] private GameObject enemy = null;
    [SerializeField] private float fireDelay = 0.1f;

    #endregion
}
