using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCommands : MonoBehaviour
{
    [SerializeField] private static List<GameObject> enemies = new List<GameObject>();

    public List<GameObject> Enemies { get { return enemies; }  set { enemies = value; } }
}
