using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    public void GoToMainMenu()
    {
        GameObject globalData = GameObject.Find("GlobalData");
        if (globalData)
        {
            Destroy(globalData);
        }
        SceneManager.LoadScene("TitleScreen");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
