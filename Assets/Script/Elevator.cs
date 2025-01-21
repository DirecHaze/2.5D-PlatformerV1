using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA, _pointB;
   
    private bool _goUp;
    private bool _canMove;
    private void FixedUpdate()
    {
        if(_canMove == true && _goUp == true)
        {
            UpMovement();
        }
        if (_canMove == true && _goUp == false)
        {
            DownMovement();
        }
    }
    private void UpMovement()
    {
        _canMove = true;
        if (Vector3.Distance(transform.position, _pointA.position) >= 0 && _goUp == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, 2 * Time.deltaTime);

        }
        //when it at Point A
        if (Vector3.Distance(transform.position, _pointA.position) <= 0)
        {
            _goUp = false;
            _canMove = false;
           
            
        }
    }
    public void DownMovement()
    {
      
        _canMove = true;
        if (Vector3.Distance(transform.position, _pointB.position) >= 0 && _goUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, 2 * Time.deltaTime);

        }
        //when it at Point B
        if (Vector3.Distance(transform.position, _pointB.position) <= 0)
        {
            _goUp = true;
            _canMove = false;

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.SetParent(this.transform);
            Debug.Log("Coming Up");
            UpMovement();
        }
        if (Vector3.Distance(transform.position, _pointA.position) <= 0 && other.tag == "Player")
        {
            other.transform.SetParent(this.transform);
            Debug.Log("Coming Down");
            DownMovement();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }

}
