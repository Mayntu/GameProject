using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerMovement : MonoBehaviour
{
    private bool left, right, up;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 leftVector, rightVector, upVector;
    private bool isRight = true;
    void Start()
    {

    }

    void Update()
    {
        PlayerWooting();
        MovementClowna();
        IsRight();
    }
    void FixedUpdate()
    {
        
    }
    private void Move(Vector3 vector)
    {
        transform.position += vector * speed * Time.deltaTime;
    }
    private void PlayerWooting()
    {
        if (left)
        {
            isRight = false;
            Move(leftVector);
        }
        if (right)
        {
            isRight = true;
            Move(rightVector);
        }
        if (up)
        {
            Move(upVector);
        }
    }
    private void MovementClowna()
    {
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        up = Input.GetKey(KeyCode.Space);
    }
    public void IsRight()
    {
        if (isRight == true)
        {
            transform.localScale = new Vector3(6.689f, 6.689f, 6.689f);
        }
        else if (isRight == false)
        {
            transform.localScale = new Vector3(-6.689f, 6.689f, 6.689f);
        }
    }
}
