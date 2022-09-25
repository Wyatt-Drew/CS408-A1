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
    public static float shape = 0f;//range accounted for



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
        float m = 0.5f;
        float r = 1f;
        float offset = -0.5f;
        if (shape <= 0f)
        {
            newVertices = new Vector3[]
            {
                new Vector3(offset, offset, 0),

                new Vector3(offset+m, offset-shape, 0),
                new Vector3(offset+m, offset-shape, 0),
                new Vector3(offset+m, offset-shape, 0),

                new Vector3(offset+r, offset, 0),

                new Vector3(offset-shape, offset+m, 0),
                new Vector3(offset-shape, offset+m, 0),
                new Vector3(offset-shape, offset+m, 0),
                new Vector3(offset-shape, offset+m, 0),

                new Vector3(offset+shape+r, offset+m, 0),
                new Vector3(offset+shape+r, offset+m, 0),
                new Vector3(offset+shape+r, offset+m, 0),
                new Vector3(offset+shape+r, offset+m, 0),

                new Vector3(offset, offset+r, 0),

                new Vector3(offset+m, offset+r+shape, 0),
                new Vector3(offset+m, offset+r+shape, 0),
                new Vector3(offset+m, offset+r+shape, 0),

                new Vector3(offset+r, offset+r, 0)

            };
        //virticies numbered from left to right then bottom to top
        
         newTriangles = new int[] { 5, 1, 0,  10, 4, 3, 13, 14, 7,  16, 17, 12, 2, 6, 9, 8, 15, 11};
         }

        if (shape > 0f)
        {
            newVertices = new Vector3[]
            {
                //centers
                new Vector3(offset, offset, 0),
                new Vector3(offset, offset + r, 0),
                new Vector3(offset + r, offset, 0),
                

                new Vector3(offset + r, offset, 0),
                new Vector3(offset, offset + r, 0),
                new Vector3(offset + r, offset + r, 0),

                //corners
                new Vector3(offset, offset + r, 0),
                new Vector3(offset, offset, 0),
                new Vector3(offset-shape, offset + m, 0),

                new Vector3(offset, offset, 0),
                new Vector3(offset + r, offset, 0),
                new Vector3(offset + m, offset-shape, 0),

                new Vector3(offset + r, offset, 0),
                new Vector3(offset + r, offset + r, 0),
                new Vector3(offset+shape+1f, offset+m, 0),

                new Vector3(offset + r, offset + r, 0),
                new Vector3(offset, offset + r, 0),
                new Vector3(offset+m, offset+shape+1f, 0)

            };
            newTriangles = new int[] { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17 };
        }
    //    newTriangles = new int[] { 0, 1, 5, 3, 4, 10, 7, 14, 13, 12, 17, 16, 2, 6, 9, 8, 15, 11 };
    //newTriangles = new int[] { 0, 5, 1, 2, 6, 9, 3, 10, 4, 7, 13, 14, 8, 15, 11, 12, 16, 17 };
    //newTriangles = new int[] { 2, 6, 9, 8, 15, 11, 1, 5, 0 };
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
                        if (shape > 1.0)
                            shape = 1.0f;
                        break;
                    }
                case 'h':
                    {
                        shape -= 0.1f;
                        if (shape < -0.25f)
                            shape = -0.25f;
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

