using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creative feature (everything)
public class ActiveParticle : MonoBehaviour
{
    //These two are assigned at time of creation by the launcher
    float rotationSpeed;
    bool gameActive;
    //These are only used in the event the game is active.  They force the
    //emission stream to have these properties
     float red = 1f;
     float blue = 0f;
     float green = 1f;
     float alpha = 1f;

    void Start()
    {
        assignRotation();
        gameActive = FindObjectOfType<MoveLauncher>().getGameActive();
        if (gameActive)
        {
            assignColor();
        }
    }
    void Update()
    {
        this.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        if (gameActive)
        {
            assignColor();
        }
    }
    void assignRotation()
    {
        rotationSpeed = FindObjectOfType<Launch>().getRotationSpeed();
    }
    void assignColor()
    {
        //fades from yellow to red
        //if (green != 0)
        //    green -= 0.5f;
        //Color32 color = new Color32(red, (byte)green, blue, (byte)alpha);//for easy math using Color32
                                                                         //fades from yellow to red
        if (green != 0)
            green -= (0.95f * Time.deltaTime);
        //green -= 0.0035f;
        //Debug.Log(green);
        Color color = new Color(red, green, blue, alpha);//for easy math using Color32
        GetComponent<Renderer>().material.color = color;
    }
}
