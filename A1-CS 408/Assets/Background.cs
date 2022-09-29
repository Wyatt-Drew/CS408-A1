using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public void toggleStars(bool toggle)
    {
        gameObject.GetComponent<ParticleSystem>().Play(); //Needed to allow particles to spawn at all
        //gameObject.GetComponent<ParticleSystem>().enableEmission = toggle; just depreciated.  Keeping it in case I need it for now.
        ParticleSystem ps = gameObject.GetComponent<ParticleSystem>(); //toggles particle emmision
        var emission = ps.emission;
        emission.enabled = toggle;
        gameObject.GetComponent<ParticleSystem>().Clear();  //clears all particles
    }
}
