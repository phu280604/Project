using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsCommands : MonoBehaviour
{
    void Start()
    {
        turretsArePlacing = new GameObject[5];
    }

    public GameObject[] TurretsArePlacing { get { return turretsArePlacing; } set{ turretsArePlacing = value; } }
    public GameObject[] TurretsAreEditing { get { return turretsAreEditing; } set { turretsAreEditing = value; } }
    public GameObject NewTurretsArePlacing { get { return newTurretsArePlacing; } set { newTurretsArePlacing = value; } }

    [SerializeField] private GameObject[] turretsArePlacing;
    [SerializeField] private GameObject[] turretsAreEditing;
    [SerializeField] private GameObject newTurretsArePlacing;
}
