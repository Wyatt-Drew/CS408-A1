using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public void toggleStars(bool toggle)
    {
        gameObject.GetComponent<ParticleSystem>().Play(); //Needed to allow particles to spawn at all
        gameObject.GetComponent<ParticleSystem>().enableEmission = toggle; //toggles particle emmision
        gameObject.GetComponent<ParticleSystem>().Clear();  //clears all particles
    }
}
