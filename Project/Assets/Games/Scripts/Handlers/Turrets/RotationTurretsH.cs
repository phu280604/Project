using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTurretsH : MonoBehaviour
{
    #region --- Method ---
    public void Rotation(Vector2 tarPos)
    {
        transform.LookAt(tarPos);
    }

    #endregion
}
