using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PatrolOfEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int positionOfPatrol;
    public Transform point;
    private bool movingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, point.position) < positionOfPatrol)
        {
            Chill();
        }
    }
    void Chill()
    {
        if(transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = true;
        }
        else if(transform.position.x < point.position.x - positionOfPatrol)
        {
            movingRight = false;
        }
        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
    void Angry()
    {

    }
    void GoBack()
    {

    }
}
