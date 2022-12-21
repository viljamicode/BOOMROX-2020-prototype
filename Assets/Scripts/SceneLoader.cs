using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevelSelectionMenu()
    {
        SceneManager.LoadScene(0);
        ShotCounterScript.shotValue = 0;
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
        ShotCounterScript.shotValue = 0;
    }

    public void LoadSecondLevel()
    {
        SceneManager.LoadScene(2);
        ShotCounterScript.shotValue = 0;
    }

    public void LoadPracticeLevel()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadThirdLevel()
    {
        SceneManager.LoadScene(4);
        ShotCounterScript.shotValue = 0;
    }
}
