using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController sharedInstance;

    public static GameController instance
    {
        get
        {
            if (sharedInstance == null)
                sharedInstance = FindObjectOfType<GameController>();
            return sharedInstance;
        }
    }

    public GoddessController goddessController;

    // Use this for initialization
    void Start()
    {
        goddessController.Enable();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
