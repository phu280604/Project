using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsCommands : MonoBehaviour
{
    #region --- Method ---
    void Start()
    {
        foreach (var item in turrets)
        {
            if (item != null)
            {
                item.SetActive(true);
                item.SetActive(false);
            }
        }
        turretsDeloyed = new List<GameObject>();
    }

    public GameObject[] Turrets { get { return turrets; } set{ turrets = value; } }
    public List<GameObject> TurretsDeloyed { get { return turretsDeloyed; } set { turretsDeloyed = value; } }

    #endregion

    #region --- Field ---

    [SerializeField] private GameObject[] turrets;
    private static List<GameObject> turretsDeloyed;

    #endregion
}
