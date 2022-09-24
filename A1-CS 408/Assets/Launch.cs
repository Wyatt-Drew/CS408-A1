using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Launch : MonoBehaviour
{
    Vector3[] newVertices;
    int[] newTriangles;

    public GameObject projectile;
    public float launchVelocity = 700f;
    public static float red = 0.25f;
    public static float green = 0.25f;
    public static float blue = 0.25f;
    public static float transparency = 1f;
    public static float size = 1f;
    public static float speed = 5f;
    public static float shape = 1f;



// Update is called once per frame
void Update()
    {
        //Updates properties before any are used
        projectileProperties();
        //Generate random angle, calculate x, y velocity so overall V is 5
        float angle = Random.Range(-30, 30);
        float yVelocity = launchVelocity * (Mathf.Sin(angle * Mathf.PI / 180));
        float xVelocity = launchVelocity * (Mathf.Cos(angle * Mathf.PI / 180));

        //
        GameObject launched = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        launched.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(xVelocity, yVelocity, 0));

        //Now that we have an object we create a custom mesh for it
        generateMesh();
        //assign mesh
        Mesh mesh = launched.GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        mesh.vertices = newVertices;
        mesh.triangles = newTriangles;
        mesh.RecalculateNormals();
        Renderer renderer = launched.GetComponent<Renderer>();
        Color color = new Color(red, green, blue, transparency);
        renderer.material.color = color;

    }

    void generateMesh()
    {
        newVertices = new Vector3[]
    {
                new Vector3(0,0,0),
                new Vector3(1,0,0),
                new Vector3(2,0,0),

                new Vector3(0,1,0),
                new Vector3(2,1,0),

                new Vector3(0,2,0),
                new Vector3(1,2,0),
                new Vector3(2,2,0)
    };
        newTriangles = new int[] { 0, 3, 1, 1, 3, 4, 1, 4, 2, 3, 5, 6, 3, 6, 4, 4, 6, 7 };
    }
    void projectileProperties()
    {
        foreach (char c in Input.inputString)
        {
            switch (c)
            {
                case 'R'://red color
                    {
                        red += 0.1f;
                        if (red > 1f)
                            red = 1f;
                        break;
                    }
                case 'r':
                    {
                        red -= 0.1f;
                        if (red < 0f)
                            red = 0f;
                        break;
                    }
                case 'G'://green
                    {
                        green += 0.1f;
                        if (green > 1f)
                            green = 1f;
                        break;
                    }
                case 'g':
                    {
                        green -= 0.1f;
                        if (green < 0f)
                            green = 0f;
                        break;
                    }
                case 'B'://blue
                    {
                        blue += 0.1f;
                        if (blue > 1f)
                            blue = 1f;
                        break;
                    }
                case 'b':
                    {
                        blue -= 0.1f;
                        if (blue < 0f)
                            blue = 0f;
                        break;
                    }
                case 'T'://Transparency
                    {
                        transparency += 0.1f;
                        if (transparency > 1f)
                            transparency = 1f;
                        break;
                    }
                case 't':
                    {
                        transparency -= 0.1f;
                        if (transparency < 0f)
                            transparency = 0f;
                        break;
                    }
                case '+'://size
                    {
                        size += 0.1f;
                        if (size > 200f)
                            size = 200f;
                        break;
                    }
                case '-':
                    {
                        size -= 0.1f;
                        if (size < 1f)
                            size = 1f;
                        break;
                    }
                case 'H'://shape
                    {
                        shape += 0.1f;
                        if (shape > 3.0)
                            shape = 3.0f;
                        break;
                    }
                case 'h':
                    {
                        shape -= 0.1f;
                        if (shape < 0.5f)
                            shape = 0.5f;
                        break;
                    }
            }
        }
        if (Input.GetKey("up"))
        {
            speed += 0.1f;
            if (speed > 10f)
                speed = 10f;
        }

        if (Input.GetKey("down"))
        {
            speed -= 0.1f;
            if (speed < 0f)
                speed = 0f;
        }

    }
}

