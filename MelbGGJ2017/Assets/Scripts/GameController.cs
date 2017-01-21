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
    public GameObject shipPrefab;

    // Use this for initialization
    void Start()
    {
        goddessController.Enable();

        SpawnShips(5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnShips(int shipCount)
    {
        Debug.Log("SpawnShips");
        for (int i = 0; i < shipCount; i++)
        {
            GameObject spawnedShip = Instantiate(shipPrefab);
            //Debug.Log(spawnedShip);
            spawnedShip.GetComponent<ShipAI>().Enable();

        }
    }
}
