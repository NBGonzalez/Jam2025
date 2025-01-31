using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{


    [SerializeField] private bool isCinematic;
    [SerializeField] private bool isLastCinematic;

    private void Update()
    {
        if (isCinematic && Input.GetKey(KeyCode.Space))
        {
            loadGame2();
        }
        else if (isLastCinematic && Input.GetKey(KeyCode.Space))
        {
            loadMenu();
        }
    }

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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }
}
