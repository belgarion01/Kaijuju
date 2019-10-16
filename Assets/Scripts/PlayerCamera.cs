using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : RotateAroundObject
{
    public Transform player;

    public float yOffset;
    public float zOffset;

    public Transform temp;

    Vector3 dic;
    Vector3 nik;

    public bool aller = false;

    private void OnEnable()
    {
        ResetPosition();
    }

    public override void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //transform.RotateAround(objectToRotateAround.position, objectToRotateAround.up, Input.GetAxis("Mouse X") * rotationSpeed);
            objectToRotateAround.RotateAround(objectToRotateAround.position, objectToRotateAround.up, Input.GetAxis("Mouse X") * rotationSpeed);
        }

        //dic = player.position - transform.position;
        //dic = player.position + player.up/*new Vector3(0f, -dic.y, 0f)*/;
        //nik = dic;
        //dic = dic - transform.position;
        //if (aller) player.LookAt(player.position + dic.normalized);

        //transform.forward = player.position - transform.position;
    }

    void ResetPosition() {
        //float value = player.up.y > 0 ? 1 : -1;
        //Vector3 pos = player.position - player.forward * zOffset - player.up * yOffset*value;
        //transform.position = pos;

        //transform.position = temp.position;
        //transform.rotation = player.rotation;

        //transform.forward = transform.position + player.transform.forward;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(player.position + dic.normalized, 0.1f);
        Gizmos.DrawSphere(player.position + dic, 0.1f);
        Gizmos.DrawWireSphere(nik, 0.1f);
    }
}
