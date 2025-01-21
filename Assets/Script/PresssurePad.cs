using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresssurePad : MonoBehaviour
{
    [SerializeField]
    private Transform _box;
    [SerializeField]
    private Rigidbody _boxRb;
    [SerializeField]
    private MeshRenderer _boxMesh;

    

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, _box.transform.position) <= 0.05)
        {
            _boxMesh.material.color = Color.blue;
            _boxRb.isKinematic = true;
            Debug.Log("At it");
        }
    }
}
