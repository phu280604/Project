using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    #region --- Method ---

    private void Start()
    {
        loadingScene.SetActive(true);
        uiGame.SetActive(false);
        Invoke("OpenGameUI", 10f);
    }

    #region -- Open game UI --
    private void OpenGameUI()
    {
        loadingScene.SetActive(false);
        uiGame.SetActive(true);
    }
    #endregion

    #endregion

    #region --- Field ---

    [SerializeField] private GameObject uiGame;
    [SerializeField] private GameObject loadingScene;

    #endregion
}
