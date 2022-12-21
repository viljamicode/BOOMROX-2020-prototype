using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCounterScript : MonoBehaviour
{

    public static int shotValue = 0;
    Text shot;

    void Start()
    {
        shot = GetComponent<Text> ();
    }

    void Update()
    {
        shot.text = "Shots : " + shotValue;
    }

}
