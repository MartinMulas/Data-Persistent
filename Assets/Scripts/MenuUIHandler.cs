using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{

    [SerializeField] InputField nameField;

    string playerName;

    public void StartNew()
    {
        NameSelection();
        DataPersistentManager.Instance.LoadBestScore();
        SceneManager.LoadScene(1);
    }

    public void ExitApp()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void NameSelection()
    {
        if(nameField.text != "")
        {
            playerName = nameField.text;
        }
        else
        {
            playerName = "Host";
        }
        
        DataPersistentManager.Instance.playerName = playerName;
    }
}
