using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
    [SerializeField]
    protected Transform objectToRotateAround;

    [SerializeField]
    protected float rotationSpeed;

    private Vector2 direction;

    private Vector2 smoothValue = Vector2.zero;

    public bool drag = true;

    public virtual void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(objectToRotateAround.position, transform.up, Input.GetAxis("Mouse X")*rotationSpeed);
            transform.RotateAround(objectToRotateAround.position, transform.right, -Input.GetAxis("Mouse Y") * rotationSpeed);
            direction = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        }

        else if ((direction.x > 0 || direction.y > 0)&&drag)
        {
            transform.RotateAround(objectToRotateAround.position, transform.up, direction.x * rotationSpeed);
            transform.RotateAround(objectToRotateAround.position, transform.right, direction.y * rotationSpeed);
            direction = Vector2.SmoothDamp(direction, Vector2.zero, ref smoothValue, 0.3f);
        }    
    }

    private void OnGUI()
    {
        //GUI.Label(new Rect(0f, 0f, 100f, 100f), temp.ToString());
    }
}
