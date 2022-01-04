using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{


    public void StartGame()
    {
        DataSaver.Instance.LoadPlayerName();
        SceneManager.LoadScene(1);

    }

    public void ExitGame()
    {
        DataSaver.Instance.SavePlayerName();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif


    }

    public void PName(string name)
    {
        DataSaver.Instance.PlayerName2 = name;
    }





}