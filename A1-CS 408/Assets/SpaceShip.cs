using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    static public bool gameActive;
    //Purpose: to allow other functions to change the gameActive status for this spaceship
    public void toggleGameActive(bool status)
    {
        gameActive = status;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive == true)
        {
            GetComponent<Renderer>().enabled = true;
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
        }
    }
}
