using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    //[SerializeField] private GameObject pauseMenu; 

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        pauseMenu.SetActive(true);
    //    }
    //}




    public void loadGame()
    {
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_CINEMATIC);
    }

    public void loadMenu()
    {
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_MAIN_MENU);
    }

    public void loadGame2()
    {
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_Game);
    }

    public void pause()
    {
        Time.timeScale = 0f;
    }

    public void resume()
    {
        Time.timeScale = 1.0f;
    }
}
