using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {

    public Transform mainMenu, optionMenu, playMenu;

    public void LoadScene(string name)
    {
        //SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    public void OptionMenu(bool clicked)
    {
        if (clicked == true)
        {
            optionMenu.gameObject.SetActive(clicked);
            optionMenu.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(false);
            Debug.Log("I'm pressed in Option if");

        }
        else
        {
            optionMenu.gameObject.SetActive(clicked);
            optionMenu.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
            Debug.Log("I'm pressed in Option else");
        }
    }

    public void PlayMenu(bool clicked)
    {
        if (clicked == true)
        {
            playMenu.gameObject.SetActive(clicked);
            playMenu.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(false);
            Debug.Log("I'm pressed in Option if");

        }
        else
        {
            playMenu.gameObject.SetActive(clicked);
            playMenu.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
            Debug.Log("I'm pressed in Option else");
        }
    }

    public void MapClicked(int level, bool clicked)
    {
        if (clicked)
        {
            SceneManager.LoadScene("UnityProject");
            SceneManager.UnloadSceneAsync("Start Menu");
        }
    }
}
