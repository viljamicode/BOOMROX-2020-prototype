using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSession : MonoBehaviour
{

    [SerializeField] float delayInSeconds = 1f;

    public GameObject Player;

    public void ReloadMap()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(0);
        ShotCounterScript.shotValue = 0;
    }

}

