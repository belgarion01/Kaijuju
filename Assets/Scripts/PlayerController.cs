using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables

    #region Components

    Rigidbody rb;

    #endregion
    #region Speed

    [SerializeField]
    private float speed;
    private float actualSpeed = 0f;
    [SerializeField]
    private float dragMultiplier;

    #endregion
    #region Other

    [SerializeField]
    private float yPositionOffset = 0.5f;
    private LayerMask planetMask;

    #endregion

    #endregion

    public int damage = 1;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        planetMask = LayerMask.NameToLayer("Planet");
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.FindObjectOfType<GameManager>().SwitchMode();
            Launch();
        }

        if (actualSpeed > 0)
        {
            Move();
        }
        else {
            actualSpeed = 0f;
        }
        //Debug.DrawRay(transform.position, -transform.up * 1f, Color.green, Mathf.Infinity);      
    }

    private void LateUpdate()
    {
        StickToGround();
    }

    void Move()
    {
        transform.position = transform.position + transform.forward * actualSpeed * Time.deltaTime;
        actualSpeed -= Time.deltaTime * dragMultiplier;
    }

    void StickToGround() {
        RaycastHit hitInfos;
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out hitInfos, planetMask))
        {
            transform.position = hitInfos.point+hitInfos.normal*yPositionOffset;
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hitInfos.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50f * Time.deltaTime);
        }
    }

    void Launch()
    {
        SetSpeed(speed);
    }

    public void SetSpeed(float speed)
    {
        actualSpeed = speed;
    }

    public float GetSpeed() {
        return actualSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Reflect(collision.contacts[0].normal);
        CheckForHit(collision.gameObject);
    }

    private void Reflect(Vector3 collisionNormal)
    {
        Vector3 targetDirection = Vector3.Reflect(transform.forward, collisionNormal);
        transform.rotation = Quaternion.LookRotation(targetDirection, transform.up);
        Debug.DrawRay(transform.position, transform.forward * 1000f, Color.red, Mathf.Infinity);
    }

    void CheckForHit(GameObject obj)
    {
        IHitable hitableObject = obj.GetComponent<IHitable>();
        hitableObject?.OnHit(damage);
    }

    private void OnGUI()
    {
        
    }
}
