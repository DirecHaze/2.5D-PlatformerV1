using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lead : MonoBehaviour
{
    public CharacterController _playerControl;
    [SerializeField]
    public Transform _snapPoint;
    [SerializeField]
    public Transform _upPoint;
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var player = transform.parent.GetComponent<Player>();
            _playerControl.enabled = true;
            player.LedgeGrab(_upPoint.transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Box")
        {
            Debug.Log("hit");
            var player = other.transform.parent.GetComponent<Player>();
            
            player.LedgeGrab(_snapPoint.transform.position);
            other.transform.SetParent(this.transform);
            _playerControl.enabled = false;
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
