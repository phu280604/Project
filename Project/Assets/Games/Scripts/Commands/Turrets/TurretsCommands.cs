using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsCommands : MonoBehaviour
{
    void Start()
    {
        turrets = new GameObject[7];
    }

    public GameObject[] Turrets { get { return turrets; } set{ turrets = value; } }

    [SerializeField] private GameObject[] turrets;
}
