using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Launch : MonoBehaviour
{
    Vector3[] newVertices;
    int[] newTriangles;

    public GameObject projectile;
    //public float speed = 5f;
    public static float red = 0.25f;
    public static float green = 0.25f;
    public static float blue = 0.25f;
    public static float transparency = 1f;
    public static float size = 100f;
    public static float speed = 700f;
    public static float shape = 0f;//measures difference from default.  Default = 1.

    //creative feature
    public static float spawnRate = 1f;
    public static float spawnCycle = 0f;
    public static float rotationSpeed = 0f;
    public bool gameActive;

    // Update is called once per frame
    void Update()
    {
        //Updates properties before any are used
        projectileProperties();
        if (gameActive)
        {
            speed = 700f;
            shape = -0.25f;
            spawnRate = 1f;
            size = 10f;
            rotationSpeed = 10f;
        }
        spawnCycle += 1;
        if (spawnCycle >= spawnRate)
        {
            spawnCycle = 0;
            //Generate random angle, calculate x, y velocity so overall V is 5
            float angle = Random.Range(-30, 30);
            float yVelocity = speed * (Mathf.Sin(angle * Mathf.PI / 180));
            float xVelocity = speed * (Mathf.Cos(angle * Mathf.PI / 180));

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
            //destory particle
            Destroy(launched, 1);
        }

    }
    //Creative feature
    public float getRotationSpeed()
    {
        return rotationSpeed;
    }
    void generateMesh()
    {                           //shape size is 1 by default.  So left is 0, middle is 0.5 and right side is 1
        float m = 0.5f * size;  //middle of shape
        float r = 1f * size;    //right side of shape
        float offset = -0.5f * size;
        float tempShape = shape * size;
        if (shape <= 0f)
        {
            newVertices = new Vector3[]
            {
                new Vector3(offset, offset, 0),

                new Vector3(offset+m, offset-tempShape, 0),
                new Vector3(offset+m, offset-tempShape, 0),
                new Vector3(offset+m, offset-tempShape, 0),

                new Vector3(offset+r, offset, 0),

                new Vector3(offset-tempShape, offset+m, 0),
                new Vector3(offset-tempShape, offset+m, 0),
                new Vector3(offset-tempShape, offset+m, 0),
                new Vector3(offset-tempShape, offset+m, 0),

                new Vector3(offset+tempShape+r, offset+m, 0),
                new Vector3(offset+tempShape+r, offset+m, 0),
                new Vector3(offset+tempShape+r, offset+m, 0),
                new Vector3(offset+tempShape+r, offset+m, 0),

                new Vector3(offset, offset+r, 0),

                new Vector3(offset+m, offset+r+tempShape, 0),
                new Vector3(offset+m, offset+r+tempShape, 0),
                new Vector3(offset+m, offset+r+tempShape, 0),

                new Vector3(offset+r, offset+r, 0)

            };
        //virticies numbered from left to right then bottom to top
        
         newTriangles = new int[] { 5, 1, 0,  10, 4, 3, 13, 14, 7,  16, 17, 12, 2, 6, 9, 8, 15, 11};
         }
        //I use a different skin when the object is bigger than default because
        //otherwise the triangles invert their direction
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
                new Vector3(offset-tempShape, offset + m, 0),

                new Vector3(offset, offset, 0),
                new Vector3(offset + r, offset, 0),
                new Vector3(offset + m, offset-tempShape, 0),

                new Vector3(offset + r, offset, 0),
                new Vector3(offset + r, offset + r, 0),
                new Vector3(offset+tempShape+size, offset+m, 0),

                new Vector3(offset + r, offset + r, 0),
                new Vector3(offset, offset + r, 0),
                new Vector3(offset+m, offset+tempShape+size, 0)

            };
            newTriangles = new int[] { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17 };
        }
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
                        size += 2f;
                        if (size > 200f)
                            size = 200f;
                        break;
                    }
                case '-':
                    {
                        size -= 2f;
                        if (size < 1f)
                            size = 1f;
                        break;
                    }
                case 'H'://shape
                    {
                        //The upper end is 3.  Default size is 1.
                        //From the limit of 1 we get 1 + 1 + 1 = 3.
                        shape += 0.1f;
                        if (shape > 1.0)
                            shape = 1.0f;
                        break;
                    }
                case 'h':
                    {
                        //lower end is 0.5.  Default size of square is 1.  
                        //From the limit of -0.25 we get 1 - 0.25 - 0.25 = 0.5
                        shape -= 0.1f;
                        if (shape < -0.25f)
                            shape = -0.25f;
                        break;
                    }
                //Creative feature
                case 'q':
                    {
                        spawnRate += 1;
                        if (spawnRate > 100f)
                            spawnRate = 100f;
                        break;
                    }
                case 'Q':
                    {
                        spawnRate -= 1;
                        if (spawnRate < 1f)
                            spawnRate = 1f;
                        break;
                    }
                //Creative feature
                case 'E':
                    {
                        rotationSpeed += 5f;
                        if (rotationSpeed > 100f)
                            rotationSpeed = 100f;
                        break;
                    }
                case 'e':
                    {
                        rotationSpeed -= 5f;
                        if (rotationSpeed < 0f)
                            rotationSpeed = 0f;
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
    public void setGameActive(bool gameActive2)
    {
        gameActive = gameActive2;
    }
}

