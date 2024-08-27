using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SpawnOnClick : MonoBehaviour
{
    #region --- Method ---
    void Start()
    {
        spawnBtn.onClick.AddListener(SpawnObject);
    }

    private void SpawnObject()
    {
        if (towerPrefab == null)
            towerPrefab = Instantiate(tower);
    }

    void Update()
    {
        if (towerPrefab != null)
        {
            StatusH status = towerPrefab.GetComponent<StatusH>();
            if (!status.IsPlacing)
            {
                towerPrefab.SetActive(true);
            }
            else
                towerPrefab = null;
        }
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameObject tower;
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private Button spawnBtn;

    #endregion
}
