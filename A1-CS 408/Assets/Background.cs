using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public void toggleStars(bool toggle)
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<ParticleSystem>().enableEmission = toggle;
    }
}
