using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class RotationTurretsH : MonoBehaviour
{
    #region --- Method ---
    public void Rotation(GameObject target)
    {
        Vector3 dirUp = Vector3.up; // Lấy vector chỉ phương mặc định v(0, 1, 0).
        Vector3 dir = target.transform.position - transform.position; // Lấy vector chỉ phương từ Turrets đến Enemies.
        
        // Lấy tích vô hướng giữa dirUp và dir.
        float dotProduct = Vector3.Dot(dir, dirUp) / (dir.magnitude * dirUp.magnitude);

        // Tính góc giữa 2 vector bằng hàm arccos() và chuyển sang độ bằng * (Mathf.Rad2Deg).
        float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        if (dir.x >= 0)
            angle = -angle;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    #endregion
}
