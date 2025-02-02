using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{


    [SerializeField] private bool isCinematic;
    [SerializeField] private bool isLastCinematic;
    private bool enter;
    private bool enter2;

    private void Start()
    {
        enter = false; 
        enter2 = false; 
    }

    private void Update()
    {
        if (isCinematic && Input.GetKey(KeyCode.Space ) && enter == false)
        {
            enter = true;
            loadGame2();
            
        }
        else if (isLastCinematic && Input.GetKey(KeyCode.Space) && enter2 == false)
        {
            enter2 = true;
            loadMenu();
        }
    }

    public void loadGame()
    {
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_CINEMATIC);
    }

    public void loadMenu()
    {
        Time.timeScale = 1.0f;
        TransitionManager.Instance.loadMenu();
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
