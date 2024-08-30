using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootH : MonoBehaviour
{
    #region --- Method ---

    #region -- Creating prefab --
    public void Shoot(Vector2 startPos, GameObject enemy)
    {
        if (enemy != null)
        {
            // Duplicate prefab.
            bulletPrefab = Instantiate(this.gameObject);

            // Set position.
            this.enemy = enemy;
            bulletPrefab.transform.position = new Vector3(startPos.x, startPos.y, -0.2f);

            // Set active.
            bulletPrefab.SetActive(true);

            // Set speed.
            speedBullet = 5;
        }
        else
        {
            this.enemy = null;
        }
    }
    #endregion

    #region -- Following enemy --
    private void Hit()
    {
        if (enemy != null)
        {
            if (GameObject.Find(enemy.name) != null)
            {
                Vector2 dir = ((Vector2)enemy.transform.position - (Vector2)transform.position);
                Vector2 dirNotmalize = dir.normalized;
                distance = dir.magnitude;

                gameObject.transform.Translate(dirNotmalize * Time.deltaTime * speedBullet);
            }
            else
            {
                this.enemy = null;
                Destroy(gameObject);
            }
        }
    }
    #endregion

    #region -- Get/Set method --
    public float GetDistance { get { return distance; } }

    public GameObject Target { get { return enemy; } }
    #endregion

    public void Update()
    {
        if (!gameCommands.PauseTime)
        {
            Hit();
        }
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameManagerCommands gameCommands;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private StatsTurrets statsTurrets;

    [SerializeField] private int speedBullet;
    [SerializeField] private float distance;

    #endregion
}
