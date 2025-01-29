
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class TransitionManager : MonoBehaviour
{
    private static TransitionManager instance;

    public static TransitionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<TransitionManager>("TransitionManager"));
                instance.Init();
            }


            return instance;
        }
    }

    public const string SCENE_MAIN_MENU = "MainMenu";
    public const string SCENE_CINEMATIC = "Cinematic";
    public const string SCENE_Game = "Jam";

    private Animator m_anim; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Init();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        m_anim = GetComponent<Animator>();  
        DontDestroyOnLoad(gameObject);

    }

    public void LoadScene(string sceneName)
    {
        gameObject.SetActive(true);
        StartCoroutine(LoadCoroutine(sceneName));
    }

    IEnumerator LoadCoroutine(string sceneName)
    {

        m_anim.SetBool("Show", true);



        yield return new WaitForSeconds(2f);

        var sceneAsync = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!sceneAsync.isDone)
        {
            
            yield return null;
        }

        if (sceneName == SCENE_CINEMATIC)
        {
            Invoke("loadGame2", 30f);
        }
        m_anim.SetBool("Show", false);
    }
    public void loadGame2()
    {
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_Game);
    }
}
