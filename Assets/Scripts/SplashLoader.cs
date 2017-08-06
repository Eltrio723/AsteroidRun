using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashLoader : MonoBehaviour {

    AsyncOperation AO;

	// Use this for initialization
	void Start () {
        StartCoroutine("LoadAsync");
        Invoke("LoadMenu", 5.5f);
	}

    void LoadMenu() {
        Debug.Log("Activacion");
        AO.allowSceneActivation = true;
    }

    IEnumerator LoadAsync() {
        AO = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        AO.allowSceneActivation = false;

        while (AO.progress < 0.9f) {
            Debug.Log("Carga completa");
            yield return null;
        }
    }

}
