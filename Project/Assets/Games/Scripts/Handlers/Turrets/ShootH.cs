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
            bulletPrefab = Instantiate(gameObject);

            // Set position.
            this.enemy = enemy;
            Vector3 dir = new Vector3(startPos.x, startPos.y, -1);
            Vector3 dirTar = enemy.transform.position - dir;
            dirTar.Normalize();
            dir += dirTar;
            bulletPrefab.transform.position = dir;

            // Set active.
            bulletPrefab.SetActive(true);

            // Set speed.
            speedBullet = 5;
        }
        else
        {
            enemy = null;
        }
    }
    #endregion

    #region -- Following enemy --
    private void Hit()
    {
        if(enemy != null)
        {
            Vector2 dir = ((Vector2)enemy.transform.position - (Vector2)transform.position);
            Vector2 dirNotmalize = dir.normalized;
            distance = dir.magnitude;

            gameObject.transform.Translate(dirNotmalize * Time.deltaTime * speedBullet);
        }
    }
    #endregion

    public float GetDistance { get { return distance; } }

    public GameObject Target { get { return enemy; } }

    public void Update()
    {
        Hit();
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private StatsTurrets statsTurrets;

    [SerializeField] private int speedBullet;
    [SerializeField] private float distance;

    #endregion
}
