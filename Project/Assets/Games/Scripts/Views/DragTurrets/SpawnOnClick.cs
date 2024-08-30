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
        if (gameCommands.BuildingTime)
        {
            StatsTurrets stats = tower.GetComponent<StatsTurrets>();
            if (towerPrefab == null && gameCommands.Cost - stats.Cost >= 0)
            {
                towerPrefab = Instantiate(tower);
                gameCommands.Cost -= stats.Cost;
                towerPrefab.name = tower.name;
                towerPrefab.SetActive(true);

                turretsCommands.TurretsDeloyed.Add(towerPrefab);
            }
            else if (towerPrefab != null && gameCommands.Cost - stats.Cost >= 0)
            {
                gameCommands.Cost -= stats.Cost;
                towerPrefab.SetActive(true);
                place.FirstHighLightPlaceTouch(place.GetTouchPosition(Input.GetTouch(0)), towerPrefab);
            }
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

    public GameObject Turret { get { return tower; } set { tower = value; } }
    public GameObject TurretPrefab { get { return towerPrefab; } set { towerPrefab = value; } }

    #endregion

    #region --- Field ---

    [Header("Game Manager")]
    [SerializeField] private GameManagerCommands gameCommands;

    [Header("Turret Components")]
    [SerializeField] private StatusH status;
    [SerializeField] private PlaceH place;
    [SerializeField] private TurretsCommands turretsCommands;

    [Header("Turret Gameobjects")]
    [SerializeField] private GameObject tower;
    [SerializeField] private GameObject towerPrefab;

    [Header("UI component")]
    [SerializeField] private Button spawnBtn;

    #endregion
}
