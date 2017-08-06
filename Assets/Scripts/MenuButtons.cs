using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

  /*  public AudioSource source;
    AsyncOperation AO;

    public Animator mainMenuAnimator;
    public Animator titleAnimator;

    private void Start() {
        StartCoroutine("LoadAsync",2);
        
    }

    private void OnLevelWasLoaded(int level) {
        if (level == 1) {
            mainMenuAnimator.SetTrigger("MenuEnter");
            titleAnimator.SetTrigger("TitleEnter");
        }
    }


    void LoadScene(int n) {
        SceneManager.LoadScene(n);
    }

    public void LaunchButton() {
        //StartCoroutine("PlaySoundAndLoad", 2);
        source.Play();
        Invoke("Load", source.clip.length);
    }

    public void ExitButton() {
        StartCoroutine("PlaySoundAndLoad", -1);
    }


    void Load() {
        SceneManager.LoadScene(2);
    }

    IEnumerator PlaySoundAndLoad(int n) {
        source.Play();
        yield return new WaitWhile(()=> source.isPlaying);
        if (n < 0)
            Application.Quit();
        else
            AO.allowSceneActivation = true;
    }

    IEnumerator LoadAsync(int n) {
        AO = SceneManager.LoadSceneAsync(n,LoadSceneMode.Additive);
        AO.allowSceneActivation = false;

        while (AO.progress < 0.9f) {
            yield return null;
        }
    }*/

}
