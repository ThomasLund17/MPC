using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapeController : MonoBehaviour
{

    public float xOffset, yOffset, zOffset, xOri, yOri, zOri;
    public float rotationAmount;

    public bool selected;
    private Vector3 position;
    private Quaternion rotation;

    void Start()
    {
        selected = false;
        position = transform.position;
        rotation = transform.rotation;
    }

    void Update()
    {

        if (selected == true)
        {
            if (Input.GetKey("up"))
            {
                rotation.x += rotationAmount;
                this.gameObject.transform.rotation = rotation;
            }

            if (Input.GetKey("down"))
            {
                rotation.x -= rotationAmount;
                this.gameObject.transform.rotation = rotation;
            }

            if (Input.GetKey("left"))
            {
                rotation.y += rotationAmount;
                this.gameObject.transform.rotation = rotation;
            }

            if (Input.GetKey("right"))
            {
                rotation.y -= rotationAmount;
                this.gameObject.transform.rotation = rotation;
            }
        }

        if (selected == false)
        {
            position.x = xOri;
            position.y = yOri;
            position.z = zOri;
            this.gameObject.transform.position = position;
        }
        else
        {
            position.x = xOffset;
            position.y = yOffset;
            position.z = zOffset;
            this.gameObject.transform.position = position;
        }
    }
}
