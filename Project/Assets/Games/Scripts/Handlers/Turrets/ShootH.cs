using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootH : MonoBehaviour
{

    public void Shoot(Vector2 startPos, Vector2 tarPos)
    {
        this.tarPos = tarPos;
        bulletPrefab = Instantiate(gameObject);
        bulletPrefab.transform.position = new Vector3(startPos.x, startPos.y, -1);
        bulletPrefab.SetActive(true);
        speedBullet = 2;
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

    #region --- Field ---

    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private StatsTurrets statsTurrets;
    [SerializeField] private SelfDestroy selfDestroy;

    [SerializeField] private Vector2 tarPos;
    [SerializeField] private int speedBullet;

    #endregion
}
