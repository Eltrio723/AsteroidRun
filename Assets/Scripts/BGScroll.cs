using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGScroll : MonoBehaviour {

    public float scrollSpeedY = 0.05f;
    public float scrollSpeedX = 0.05f;
    Rect uv;
    RawImage background;

    void Start(){
        background = GetComponent<RawImage>();
        uv = background.uvRect;
    }

    void Update() {
        uv = new Rect(uv.x + scrollSpeedX * Time.deltaTime, uv.y + scrollSpeedY * Time.deltaTime, uv.width, uv.height);
        background.uvRect = uv;

        /*if (SwipeManager.IsSwipingDown()) {
            SceneManager.LoadScene(2);
        }*/
    }

}
