using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseStartH : MonoBehaviour
{

    #region --- Method ---

    private void Start()
    {
        button.onClick.AddListener(GamePauseStart);
    }

    #region -- Pause/Start --
    private void GamePauseStart()
    {
        if (pause.activeSelf)
        {
            gameManagerCommands.PauseTime = true;
            gameManagerCommands.StartTime = false;

            start.SetActive(true);
            pause.SetActive(false);

            Time.timeScale = 0f;
        }
        else
        {
            gameManagerCommands.PauseTime = false;
            gameManagerCommands.StartTime = true;
            gameManagerCommands.BuildingTime = false;

            start.SetActive(false);
            pause.SetActive(true);
            
            Time.timeScale = 1f;
        }
    }
    #endregion
    
    #region -- Next wave --
    public void NextWave()
    {
        gameManagerCommands.PauseTime = true;
        gameManagerCommands.StartTime = false;

        start.SetActive(true);
        pause.SetActive(false);

        gameManagerCommands.Wave += 1;
        gameManagerCommands.BuildingTime = true;

        enemies.SetActive(false);
        enemies.SetActive(true);
    }
    #endregion

    #endregion

    #region --- Field ---

    [SerializeField] private GameManagerCommands gameManagerCommands;
    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject start;
    [SerializeField] private Button button;

    #endregion
}
