using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfrom : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA, _pointB;
    [SerializeField]
    private bool _goBack;
   

    // Update is called once per frame
  private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        if (Vector3.Distance(transform.position, _pointB.position) >= 0 && _goBack == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, 2 * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, _pointB.position) <= 0)
        {
            _goBack = true;
        }

        if (Vector3.Distance(transform.position, _pointA.position) >= 0 && _goBack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, 2 * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, _pointA.position) <= 0)
        {
            _goBack = false;
        }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.SetParent(this.transform);
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
