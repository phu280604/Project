using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SpawnHandle : MonoBehaviour
{
    private void Start()
    {
        mapD = GameObject.Find("Map").GetComponent<MapDatas>();

        enemies = new List<GameObject> ();
        enemyCategories = new Dictionary<GameObject, int>();

        enemyCategories[GameObject.FindWithTag("MiniVanguard")] = 0;
        enemyCategories[GameObject.FindWithTag("MiniGuard")] = 0;
        enemyCategories[GameObject.FindWithTag("MiniSniper")] = 0;
        enemyCategories[GameObject.FindWithTag("EliDefender")] = 0;
        enemyCategories[GameObject.FindWithTag("EliSniper")] = 0;

        //maxEnemy = Random.Range(7, 10);

        int minEnemy = 0;

        foreach (KeyValuePair<GameObject, int> item in enemyCategories)
        {
            GameObject enemiesPrefab = Instantiate(item.Key);
            int randomNums = Random.Range(minEnemy, maxEnemy);
            for (int i = 0; i < randomNums; i++)
            {
                enemiesPrefab.name = item.Key.tag + $" #{i + 1}";
                enemiesPrefab.transform.position = mapD.StartPoint.transform.position;
                enemies.Add(enemiesPrefab);
            }

            //enemyCategories[item.Key] = randomNums;
            minEnemy = randomNums;
        }
    }

    [SerializeField] private Dictionary<GameObject, int> enemyCategories;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private MapDatas mapD;
    [SerializeField] private int maxEnemy;
}
