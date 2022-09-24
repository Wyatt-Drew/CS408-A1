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
                        Debug.Log(red);
                        break;
                    }
                case 'r':
                    {
                        red -= 0.1f;
                        Debug.Log("r");
                        break;
                    }
                case 'G'://green
                    {
                        green += 0.1f;
                        Debug.Log("r");
                        break;
                    }
                case 'g':
                    {
                        green -= 0.1f;
                        Debug.Log("r");
                        break;
                    }
                case 'B'://blue
                    {
                        blue += 0.1f;
                        Debug.Log("r");
                        break;
                    }
                case 'b':
                    {
                        blue -= 0.1f;
                        Debug.Log("r");
                        break;
                    }
                case 'T'://Transparency
                    {
                        transparency += 0.1f;
                        Debug.Log("r");
                        break;
                    }
                case 't':
                    {
                        transparency -= 0.1f;
                        Debug.Log("r");
                        break;
                    }
                case '+'://size
                    {
                        size += 0.1f;
                        Debug.Log("r");
                        break;
                    }
                case '-':
                    {
                        size -= 0.1f;
                        Debug.Log("r");
                        break;
                    }
                case 'H'://shape
                    {
                        shape += 0.1f;
                        Debug.Log("r");
                        break;
                    }
                case 'h':
                    {
                        shape -= 0.1f;
                        Debug.Log("r");
                        break;
                    }
            }
        }
        if (Input.GetKey("up"))
        {
            speed += 0.1f;
            print("up arrow key is held down");
        }

        if (Input.GetKey("down"))
        {
            speed -= 0.1f;
            print("down arrow key is held down");
        }

    }
}

