using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creative feature
public class ActiveParticle : MonoBehaviour
{
    static float rotationSpeed;
    static bool gameActive;
     byte red = 255;
     byte blue = 0;
     float green = 255f;
     byte alpha = 1;
    // Start is called before the first frame update
    void Start()
    {
        assignRotation();
        gameActive = FindObjectOfType<MoveLauncher>().getGameActive();
        if (gameActive)
        {
            assignColor();
        }
    }

    // Update is called once per frame
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
        Color32 color = new Color32(red, (byte)green, blue, alpha);
        //Color color = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = color;
    }
}
