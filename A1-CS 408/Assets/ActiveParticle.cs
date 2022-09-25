using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActiveParticle : MonoBehaviour
{
    static float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        assignRotation();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        //this.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    void assignRotation()
    {
        rotationSpeed = FindObjectOfType<Launch>().getRotationSpeed();
    }
}
