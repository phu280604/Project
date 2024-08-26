using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootH : MonoBehaviour
{
    #region --- Method ---

    public void Shoot(Vector2 startPos, Vector2 tarPos)
    {
        if (bullets.Count <= 1)
        // Duplicate prefab.
        bulletPrefab = Instantiate(gameObject);

        // Set position.
        this.tarPos = tarPos;
        Vector3 dir = new Vector3(startPos.x, startPos.y, -1);
        Vector3 dirTar = (Vector3)tarPos - dir;
        dirTar.Normalize();
        dir += dirTar;
        bulletPrefab.transform.position = dir;

        // Set active.
        bulletPrefab.SetActive(true);

        // Set speed.
        speedBullet = 5;
    }

    private void Hit()
    {
        Vector2 dir = (this.tarPos - (Vector2)transform.position);
        Vector2 dirNotmalize = dir.normalized;
        float dirMagnitude = dir.magnitude;

        if (dirMagnitude < 0.1) selfDestroy.SeltDes();

        gameObject.transform.Translate(dirNotmalize * Time.deltaTime * speedBullet);
    }

    public void Update()
    {
        Hit();
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private StatsTurrets statsTurrets;
    [SerializeField] private SelfDestroy selfDestroy;

    [SerializeField] private Vector2 tarPos;
    [SerializeField] private List<GameObject> bullets;
    [SerializeField] private int speedBullet;

    #endregion
}
