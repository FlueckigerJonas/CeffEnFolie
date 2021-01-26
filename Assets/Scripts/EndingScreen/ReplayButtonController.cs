using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayButtonController : MonoBehaviour
{
    public void onClickReplay()
    {
        StaticGameData.isLost = false;
        StaticGameData.Game.Points = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("EndingScreen");

    }

}
