using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScroll : MonoBehaviour {

    public float speed = 40;

    void Update () {
        float posY = Mathf.MoveTowards(transform.position.y, transform.position.y - 100, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        if (transform.position.y < -70)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        FindObjectOfType<GameController>().ShipCrash();
        Destroy(gameObject);
    }

}
