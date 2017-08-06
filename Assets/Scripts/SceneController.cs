using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    static AsyncOperation AO;

    Animator mainMenuAnimator;
    Animator titleAnimator;

    void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    private void Awake() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        switch (scene) {
            case 0:
                //StartCoroutine("LoadAsync", 1);
                Invoke("LoadMenu", 5.5f);
                //Invoke("GoToPreloadedScene", 5.5f);
                break;
            case 1:
                //StartCoroutine("LoadAsync", 2);
                /*mainMenuAnimator = GameObject.Find("MenuCanvas/MainMenu").GetComponent<Animator>();
                titleAnimator = GameObject.Find("MenuCanvas/Title").GetComponent<Animator>();
                mainMenuAnimator.SetTrigger("MenuEnter");
                titleAnimator.SetTrigger("TitleEnter");*/
                break;
            case 2:
                //StartCoroutine("LoadAsync", 1);
                break;
        }
    }


    public void GoToPreloadedScene() {
        AO.allowSceneActivation = true;
    }



    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenuFromPause() {
        SceneManager.LoadScene(1);
    }

    public void LoadMenuFromGameover() {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel(){
        SceneManager.LoadScene(2);
    }

    public void MenuExitButton(){
        Application.Quit();
    }

    /*IEnumerator LoadAsync(int n) {
        AO = SceneManager.LoadSceneAsync(n, LoadSceneMode.Additive);
        AO.allowSceneActivation = false;

        while (AO.progress < 0.9f) {
            yield return null;
        }
    }*/

}
