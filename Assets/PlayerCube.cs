using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
    public bool isControlled = false;
    public float speed = 2f;
    public float jumpSpeed = 20f;
    private bool isOnGround = true;

    Rigidbody body;

    void UpdateControlChild()
    {
        Transform child = transform.Find("Control");
        if (child != null)
        {
            child.gameObject.SetActive(isControlled);
        }
        else
        { 
            Debug.LogWarning("mon gars");
        }
    }

    void Move() 
    {
        float x = speed * Input.GetAxis("Horizontal");
        float y = body.velocity.y;
        float z = speed * Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true) 
        {
            y = jumpSpeed;
            isOnGround=false;
        }

        body.velocity = new Vector3(x, y, z);
    }
    
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Sol") {
            isOnGround=true;
        }
    }

    void Start()
    {
        body = GetComponent<Rigidbody>();
        UpdateControlChild();
    }

    void Update()
    {
        if (isControlled == true)
        {
            Move();
        }
    }

    void OnMouseDown()
    {
        isControlled = !isControlled;
        UpdateControlChild();
    }
}
