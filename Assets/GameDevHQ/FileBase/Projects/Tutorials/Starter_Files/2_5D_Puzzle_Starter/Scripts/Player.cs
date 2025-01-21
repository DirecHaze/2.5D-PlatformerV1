using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private float _moveForec = 1;
    private bool _canDoubleJump = false;
    [SerializeField]
    private bool _canWallJump;
    [SerializeField]
    private int _coins;
    private UIManager _uiManager;
    private ElevatorButton _elevatorButton;
    [SerializeField]
    private int _lives = 3;
    private Vector3 _direction, _velocity;
    private Vector3 _wallSurfaceNormal;
    

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _elevatorButton = GameObject.Find("Elevator_Panel").GetComponent<ElevatorButton>();
        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL."); 
        }

        _uiManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {

        if (_controller.isGrounded == true)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            _direction = new Vector3(horizontalInput, 0, 0);
            _velocity = _direction * _speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
            _canWallJump = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight * 0.5f;
                   
                    _canDoubleJump = false;
                  
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && _canWallJump == true)
            {

                _velocity = _wallSurfaceNormal * _speed;
                _yVelocity = _jumpHeight;


            }
                _yVelocity -= _gravity;
        }

        _velocity.y = _yVelocity;

        _controller.Move(_velocity * Time.deltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(_controller.isGrounded == true && hit.transform.tag == "MovableBox")
        {
            Rigidbody BoxRb = hit.collider.attachedRigidbody;
            Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, 0);
            BoxRb.velocity = pushDirection * _moveForec;
            
        }
      
        if (_controller.isGrounded == false && hit.transform.tag == "Wall")
        {
            Debug.DrawRay(transform.position, hit.normal, Color.red, 1);
            _wallSurfaceNormal = hit.normal;
            _canWallJump = true;
            _canDoubleJump = false;
           
        }
     
    }
   

    public void AddCoins()
    {
        _coins++;
        _elevatorButton.PlayerCoinCount();
        _uiManager.UpdateCoinDisplay(_coins);
    }

    public void Damage()
    {
        _lives--;

        _uiManager.UpdateLivesDisplay(_lives);

        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void LedgeGrab(Vector3 snapPoint)
    {
        
        transform.position = snapPoint * Time.deltaTime;
       
       
    }
    
}
