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
        index = 1;
        spawnBtn.onClick.AddListener(SpawnObject);
    }

    private void SpawnObject()
    {
        if (towerPrefab == null)
        {
            towerPrefab = Instantiate(tower);
        }
    }

    void Update()
    {
        if (towerPrefab != null && tower.tag == towerPrefab.tag)
        {
            if (!status.IsPlacing && Input.touchCount > 0)
            {
                towerPrefab.SetActive(true);
                place.FirstHighLightPlaceTouch(place.GetTouchPosition(Input.GetTouch(0)), towerPrefab);
                towerPrefab.tag = "TurretClone";
            }
        }
    }

    #endregion

    #region --- Field ---

    [SerializeField] private StatusH status;
    [SerializeField] private PlaceH place;
    [SerializeField] private GameObject tower;
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private Button spawnBtn;

    private int index;

    #endregion
}
