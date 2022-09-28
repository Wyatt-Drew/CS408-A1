using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creative feature (everything)
public class ActiveParticle : MonoBehaviour
{
    float rotationSpeed;
    bool gameActive;
     byte red = 255;
     byte blue = 0;
     float green = 255f;
     float alpha = 255f;

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
        if (green != 0)
            green -= 0.5f;
        Color32 color = new Color32(red, (byte)green, blue, (byte)alpha);
        GetComponent<Renderer>().material.color = color;
    }
}
