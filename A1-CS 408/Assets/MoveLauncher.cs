using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLauncher : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0f, 0.1f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, -0.1f, 0f);
        }
        if (Input.GetKey("left"))
        {
            this.transform.Rotate(0, 0, 1);
        }
        if (Input.GetKey("right"))
        {
            this.transform.Rotate(0, 0, -1);
        }
    }
}
