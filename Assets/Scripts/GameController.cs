using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public int points = 0;
    public int lives = 3;
    bool pointsAllowed = true;

    public ParticleSystem explosion;
    GameObject spaceship = null;


    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    /*private void Awake() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 2)
            spaceship = GameObject.FindGameObjectWithTag("Player");
    }*/

    public void SetSpaceship(GameObject ship) {
        spaceship = ship;
    }

    public void StartPoints() {
        StartCoroutine("PointsOverTime");
    }

    public int GetPoints() {
        return points;
    }

    void IncreasePoints(int n) {
        points += n;
        FindObjectOfType<Hud>().DrawPoints(points);
    }

    void DecreasePoints(int n) {
        points -= n;
        if (points < 0)
            points = 0;
        FindObjectOfType<Hud>().DrawPoints(points);
    }

    void IncreaseLives(int n) {
        lives += n;
        FindObjectOfType<Hud>().DrawLives(lives);
    }

    void DecreaseLives(int n) {
        lives -= n;
        if (lives < 0)
            lives = 0;
        FindObjectOfType<Hud>().DrawLives(lives);
    }

    public void ResetStats() {
        pointsAllowed = true;
        points = 0;
        lives = 3;
    }


    public void ShipCrash() {
        DecreasePoints(80);
        DecreaseLives(1);
        pointsAllowed = false;
        spaceship.SetActive(false);
        spaceship.GetComponent<Spaceship>().enabled = false;
        Instantiate(explosion, spaceship.transform.position + new Vector3(0,5,0), Quaternion.Euler(0,180,0));
        if (lives == 0)
            GameObject.FindObjectOfType<Gameover>().GameOver();
        else
            StartCoroutine("RespawnShip");
    }

    public void Restart() {
        ResetStats();
        GameObject.FindObjectOfType<SceneController>().LoadLevel();
    }


    IEnumerator RespawnShip() {
        spaceship.transform.position = new Vector3(0, spaceship.transform.position.y, spaceship.transform.position.z);
        FindObjectOfType<ObstacleManager>().SpawnObstacles(false);

        yield return new WaitForSeconds(3f);

        spaceship.SetActive(true);
        spaceship.GetComponent<Spaceship>().enabled = true;
        FindObjectOfType<ObstacleManager>().SpawnObstacles(true);
        pointsAllowed = true;
        yield return null;
    }

    IEnumerator PointsOverTime() {
        while (true) {
            if(pointsAllowed)
                IncreasePoints(1);
            yield return new WaitForSeconds(0.1f);
        }
    }

}
