﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StaticGameData.saveHighScore();
        GameObject.Find("Score").GetComponent<Text>().text = "" + StaticGameData.Game.Points;
        GameObject.Find("HighScore").GetComponent<Text>().text = "" + StaticGameData.getHighScore();
    }
}
