using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuHSUpdater : MonoBehaviour {

	void OnEnable () {
        GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetInt("HighScore",0);
	}
	
}
