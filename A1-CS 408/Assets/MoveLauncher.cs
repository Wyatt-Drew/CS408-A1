using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.CoreModule;

public class MoveLauncher : MonoBehaviour
{
    public static float x = 0f;
    public static float y = 0f;
    public static float xboarder = 21.2f;//17.3
    public static float yboarder = 11.9f;//5.6
    public GameObject projectile;
    //creative elements
    public static bool gameActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (x > -xboarder)
            {
                //this.transform.position.x;
                x = x - 0.1f;
                //this.transform.Translate(0, 0, Time.deltaTime);
                this.transform.Translate(-0.1f, 0f, 0f, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (x < xboarder)
            {
                x = x + 0.1f;
                this.transform.Translate(0.1f, 0f, 0f, Space.World);
            }

        }
        if (Input.GetKey(KeyCode.W))
        {
            if (y < yboarder)
            {
                this.transform.Translate(0f, 0.1f, 0f, Space.World);
                y = y + 0.1f;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (y > -yboarder)
            {
                y = y - 0.1f;
                this.transform.Translate(0.0f, -0.1f, 0f, Space.World);
            }
        }
        if (Input.GetKey("left"))
        {
            this.transform.Rotate(0, 0, 1);
        }
        if (Input.GetKey("right"))
        {
            this.transform.Rotate(0, 0, -1);
        }
        foreach (char c in Input.inputString)
        {
            switch (c)
            {
                case 'F'://astroid game
                    {
                        Renderer[] currentRenderers;
                        if (gameActive != true)
                        {
                            gameActive = true;
                            FindObjectOfType<Launch>().setGameActive(gameActive);
                            GetComponent<AudioSource>().Play();
                            FindObjectOfType<Background>().toggleStars(true);
                        }
                        break;
                    }
                case 'f'://quit astroid game
                    {
                        if (gameActive == true)
                        {
                            gameActive = false;
                            FindObjectOfType<Launch>().setGameActive(gameActive);
                            GetComponent<AudioSource>().Stop();
                            FindObjectOfType<Background>().toggleStars(false);
                        }
                        
                        break;
                    }
            }
        }

    }
    public bool getGameActive()
    {
        return gameActive;
    }
}

