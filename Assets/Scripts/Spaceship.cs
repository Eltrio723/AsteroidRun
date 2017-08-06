using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour {


    //This script is used to move the player between lanes
    //This must be contained by the spaceship

    public Transform leftLane;
    public Transform centralLane;
    public Transform rightLane;

    public Animator animator;


    public float speed = 60f;

    public int currentLane = 1;
    private bool moving = false;

    private void Start() {
        FindObjectOfType<GameController>().SetSpaceship(gameObject);
    }

    void Update()
    {
        /*if (transform.position.x < 0)
            currentLane = 0;
        else if (transform.position.x > 0)
            currentLane = 2;
        else
            currentLane = 1;*/


        if ((SwipeManager.IsSwipingRight() || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            if (currentLane == 0)
            {
                //animator.SetTrigger("LeanRight");
                //StartCoroutine("SwitchLane", centralLane);
                currentLane = 1;
                animator.SetTrigger("CL01");
                animator.ResetTrigger("CL12");
                animator.ResetTrigger("CL10");
                animator.ResetTrigger("CL21");
            }
            else if (currentLane == 1)
            {
                //animator.SetTrigger("LeanRight");
                //StartCoroutine("SwitchLane", rightLane);
                currentLane = 2;
                animator.SetTrigger("CL12");
                animator.ResetTrigger("CL01");
                animator.ResetTrigger("CL10");
                animator.ResetTrigger("CL21");
            }
        }

        else if ((SwipeManager.IsSwipingLeft() || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            if (currentLane == 1)
            {
                //animator.SetTrigger("LeanLeft");
                //StartCoroutine("SwitchLane", leftLane);
                currentLane = 0;
                animator.SetTrigger("CL10");
                animator.ResetTrigger("CL12");
                animator.ResetTrigger("CL01");
                animator.ResetTrigger("CL21");
            }
            else if (currentLane == 2)
            {
                //animator.SetTrigger("LeanLeft");
                //StartCoroutine("SwitchLane", centralLane);
                currentLane = 1;
                animator.SetTrigger("CL21");
                animator.ResetTrigger("CL12");
                animator.ResetTrigger("CL01");
                animator.ResetTrigger("CL10");
            }
        }

    }

    IEnumerator SwitchLane(Transform lane) {
        Debug.Log("Move");
        moving = true;
        float posX = 0f;
        float delta = (transform.position - lane.position).magnitude;

        while (delta>0.1){
            posX = Mathf.MoveTowards(transform.position.x, lane.position.x, speed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
            transform.position = new Vector3(posX, transform.position.y, transform.position.z);
            delta = (transform.position - lane.position).magnitude;
            Debug.Log(posX);
        }

        Debug.Log("Move complete");


        if (lane.position.x < -1)
            currentLane = 0;
        else if (lane.position.x > 1)
            currentLane = 2;
        else
            currentLane = 1;

        //yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"));
        moving = false;

        yield return null;
    }

}
