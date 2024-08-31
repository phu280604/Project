using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    #region --- Method ---

    #region -- Start game --
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    #endregion

    #region -- Collection --
    public void Collection()
    {
        //SceneManager.LoadScene("Collection");
    }
    #endregion

    #region -- Quit game --
    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion

    #region -- Main menu --
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

    #region -- Reset game --
    public void ResetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlay");
    }
    #endregion

    #region -- Resume game --

    public void ResumeGame()
    {
        GameObject settingObj = GameObject.FindWithTag("Setting");
        if (settingObj != null)
        {
            GameManagerCommands gameCommand = GameObject.FindWithTag("GameController").GetComponent<GameManagerCommands>();
            gameCommand.PauseTime = false;
            gameCommand.StartTime = true;
            gameCommand.BuildingTime = false;
            settingObj.SetActive(false);
        }
        else
        {
            Debug.Log("Can't find obj");
        }
    }
    #endregion

    #endregion
}
