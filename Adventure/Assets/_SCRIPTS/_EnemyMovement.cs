using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3[] positions;
    private int currentTarget;
    private bool isRight = false;
    public void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed);

        if (transform.position == positions[currentTarget])
        {
            if (currentTarget < positions.Length - 1)
            {
                currentTarget++;
                isRight = true;
            }
            else
            {
                currentTarget = 0;
                isRight = false;
            }
        }
        IsRight();
    }
    public void IsRight()
    {
        if (isRight == true)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (isRight == false)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}