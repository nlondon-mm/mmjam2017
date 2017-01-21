using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoddessController : MonoBehaviour
{

    private float spacebarTime;
    private bool spaceBarDown = false;

    public void Enable()
    {
        Debug.Log("GoddessController Enable");
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpaceBar();
    }

    private void TimeSpaceBar()
    {
        if (Input.GetKeyDown("space"))
        {

            spacebarTime = 0f;
            Debug.Log("STARTED SPACING AT " + spacebarTime);
            spaceBarDown = true;
        }
        if (Input.GetKey("space"))
        {

            spacebarTime += Time.deltaTime;
            Debug.Log("Spacebar pressed, current length: " + spacebarTime);
        }
        if (Input.GetKeyUp("space"))
        {
            Debug.Log("RELEASED THE SPACEBAR AFTER " + spacebarTime);
            spaceBarDown = false;
        }
    }
}
