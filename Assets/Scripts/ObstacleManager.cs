using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

    public Transform spawner;

    public bool spawn = true;

    public List<GameObject> obstacleList;

    private void Start() {
        StartCoroutine("SpawnObstacle");
    }

    public void SpawnObstacles(bool t) {
        spawn = t;
    }



    IEnumerator SpawnObstacle() {
        int obstacle;
        while (true) {
            obstacle = Random.Range(0,obstacleList.Count);
            if (!spawn)
                obstacle = 0;
            Instantiate(obstacleList[obstacle], spawner.position, spawner.rotation);
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

}
