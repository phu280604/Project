using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class THealthBarCtrl : MonoBehaviour
{
    #region --- Method ---

    public void UpdateHelthBar(float hp, float maxHp)
    {
        healthBar.value =  hp / maxHp;
    }

    #endregion

    #region --- Field ---

    [SerializeField] private Slider healthBar;

    #endregion
}
