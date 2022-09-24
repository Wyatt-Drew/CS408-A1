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
                        Debug.Log("R");
                        break;
                    }
                case 'r':
                    {
                        Debug.Log("r");
                        break;
                    }
                case 'G'://green
                    {
                        Debug.Log("r");
                        break;
                    }
                case 'g':
                    {
                        Debug.Log("r");
                        break;
                    }
                case 'B'://blue
                    {
                        Debug.Log("r");
                        break;
                    }
                case 'b':
                    {
                        Debug.Log("r");
                        break;
                    }
                case 'T'://Transparency
                    {
                        Debug.Log("r");
                        break;
                    }
                case 't':
                    {
                        Debug.Log("r");
                        break;
                    }
                case '+'://size
                    {
                        Debug.Log("r");
                        break;
                    }
                case '-':
                    {
                        Debug.Log("r");
                        break;
                    }
                case 'H'://shape
                    {
                        Debug.Log("r");
                        break;
                    }
                case 'h':
                    {
                        Debug.Log("r");
                        break;
                    }
            }
        }
        if (Input.GetKey("up"))
        {
            print("up arrow key is held down");
        }

        if (Input.GetKey("down"))
        {
            print("down arrow key is held down");
        }
        if (Input.GetKey("left"))
        {
            print("up arrow key is held down");
        }

        if (Input.GetKey("right"))
        {
            print("down arrow key is held down");
        }
    }
}

