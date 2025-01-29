
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cinematic : MonoBehaviour
{
    private static Cinematic instance;

    public static Cinematic Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<Cinematic>("TransitionManager"));
            }


            return instance;
        }
    }

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

        DontDestroyOnLoad(gameObject);

    }
    // Update is called once per frame
    //void Update()
    //{
    //    Invoke("LoadGame", 30f);
    //}



    //public void LoadGame()
    //{
    //    SceneManager.LoadScene(2);
    //}

    IEnumerator LoadCoroutine(string sceneName)
    {




        yield return new WaitForSeconds(2f);

        var sceneAsync = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!sceneAsync.isDone)
        {

            yield return null;
        }


    }

}
