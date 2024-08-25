using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SniperH : MonoBehaviour
{
    #region --- Method ---

    private void StatsSetUp()
    {
        switch (layer)
        {
            case int n when n == LayerMask.GetMask("SniperTur"):
                statsH.StatsSniper();
                break;
        }
    }

    private void Start()
    {
        StatsSetUp();
    }

    private void EnemiesChecker()
    {
        float distance = 0;
        foreach (GameObject enemies in eCommands.Enemies)
        {
            distance = ((Vector2)(transform.position - enemies.transform.position)).magnitude;
            if (distance <= statsH.AtkRange)
            {
                Debug.Log("shoot");
            }
        }
    }

    private void Update()
    {
        EnemiesChecker();
    }

    #endregion

    #region --- Field ---

    [SerializeField] LayerMask layer;

    [SerializeField] private ShootH shoot;
    [SerializeField] private RotationTurretsH rotationH;
    [SerializeField] private StatsTurrets statsH;

    [SerializeField] private EnemiesCommands eCommands;

    #endregion
}
