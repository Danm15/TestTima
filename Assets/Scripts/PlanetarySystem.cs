using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystem : MonoBehaviour
{
    private float G = 0.001f;
    private GameObject[] spaceObjects;

    // Start is called before the first frame update
    void Start()
    {
        spaceObjects = GameObject.FindGameObjectsWithTag("SpaceObjects");
        InitialSpeed();
    }

    private void FixedUpdate()
    {
        Gravity();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void Gravity()
    {
        foreach(GameObject spaceObject in spaceObjects)
        {
            foreach (GameObject otherSpaceObject in spaceObjects)
            {
                float massSpaceObject = spaceObject.GetComponent<Rigidbody>().mass;
                float massOtherSpaceObject = otherSpaceObject.GetComponent<Rigidbody>().mass;
                float distanceBetween = Vector3.Distance(spaceObject.transform.position, otherSpaceObject.transform.position);
                if (distanceBetween != 0)
                {
                    spaceObject.GetComponent<Rigidbody>().AddForce((otherSpaceObject.transform.position - spaceObject.transform.position).normalized *
                   ((G * massSpaceObject * massOtherSpaceObject) / (distanceBetween * distanceBetween)));
                }

               
               
                
            }
        }
    }

    void InitialSpeed()
    {
        foreach (GameObject spaceObject in spaceObjects)
        {
            foreach (GameObject otherSpaceObject in spaceObjects)
            {
                if (!spaceObject.Equals(otherSpaceObject))
                {
                    float massOtherSpaceObject = otherSpaceObject.GetComponent<Rigidbody>().mass;
                    float distanceBetween = Vector3.Distance(spaceObject.transform.position, otherSpaceObject.transform.position);
                    spaceObject.transform.LookAt(otherSpaceObject.transform);

                    spaceObject.GetComponent<Rigidbody>().velocity += spaceObject.transform.right * Mathf.Sqrt((G * massOtherSpaceObject) / (distanceBetween ));
                }
               
                

                
            }
        }
    }
}
