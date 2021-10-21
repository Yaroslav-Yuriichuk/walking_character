using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _animator;

    private int _speedHash;
    
    private float _speed = 0f;
    private const float _maxSpeed = 6f;
    private const float _speedAcceleration = 2f;
    private const float _speedDeacceleration = -4f;
    
    private const float _turnSpeed = 160f;
    /*private const float _maxTurnSpeed = 180f;
    private const float _turnAcceleration = 90f;
    private const float _turnDeacceleration = -135f;*/

    private void Start()
    {
        _speedHash = Animator.StringToHash("Speed");
    }

    private void Update()
    {
        int move = (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0);
        int turn = (Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);

        if (move > 0)
        {
            _speed = Mathf.Min(_speed + _speedAcceleration * Time.deltaTime, _maxSpeed);
        }
        else
        {
            _speed = Mathf.Max(_speed + _speedDeacceleration * Time.deltaTime, 0);
        }
        
        _animator.SetFloat(_speedHash, _speed);
        
        _characterController.Move(transform.forward * _speed * Time.deltaTime);
        transform.Rotate(Vector3.up, _turnSpeed * turn * Time.deltaTime);
    }

}
