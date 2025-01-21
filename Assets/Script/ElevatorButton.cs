using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    public Elevator _elevator;
    public MeshRenderer _mesh;
    [SerializeField]
    private int _coin;
    private bool _stopCount;
   
   
    public void PlayerCoinCount()
    {
        if (_stopCount == false)
        {
            _coin++;
        }
    }
    private void OnTriggerStay(Collider other)
    {


        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Botton works");
            }
        }

        if (other.tag == "Player" && _coin == 8)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                _elevator.DownMovement();
                _stopCount = true;
                _mesh.material.color = Color.green;
                
                Debug.Log("Coming Down");
            }
        }


    }
    
}

