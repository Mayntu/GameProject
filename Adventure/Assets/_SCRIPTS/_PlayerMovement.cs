using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerMovement : MonoBehaviour
{
    private bool left, right, up;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 leftVector, rightVector, upVector;
    void Start()
    {


    }

    void Update()
    {
        PlayerWooting();
        MovementClowna();
    }
    private void Move(Vector3 vector)
    {
        transform.position += vector * speed * Time.deltaTime;
    }
    private void PlayerWooting()
    {
        if (left)
        {
            Move(leftVector);
        }
        if (right)
        {
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
}
