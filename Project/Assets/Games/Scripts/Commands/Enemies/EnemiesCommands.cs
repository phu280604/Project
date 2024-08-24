using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCommands : MonoBehaviour
{
    private void Start()
    {
        spawnH = gameObject.GetComponent<SpawnHandle>();
    }

    [SerializeField] private SpawnHandle spawnH;
}
