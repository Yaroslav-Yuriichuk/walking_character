using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _animator;

    public float TotalDistance { get; private set; }
        
    private int _speedHash;

    private const float Gravity = -9.81f;
    
    private float _speed = 0f;
    private const float MaxSpeed = 6f;
    private const float SpeedAcceleration = 5f;
    private const float SpeedDecceleration = -4f;
    
    private const float TurnSpeed = 160f;

    private float _fallingSpeed = 0f;
    private void Start()
    {
        Cursor.visible = false;
        TotalDistance = 0;
        _speedHash = Animator.StringToHash("Speed");
    }

    private void Update()
    {
        int move = (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0);
        int turn = (Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);

        if (move > 0)
        {
            _speed = Mathf.Min(_speed + SpeedAcceleration * Time.deltaTime, MaxSpeed);
        }
        else
        {
            _speed = Mathf.Max(_speed + SpeedDecceleration * Time.deltaTime, 0);
        }

        _animator.SetFloat(_speedHash, _speed);

        _characterController.Move(transform.forward * _speed * Time.deltaTime);
        TotalDistance += _speed * Time.deltaTime;
            
        if (_speed > 0)
        {
            transform.Rotate(Vector3.up, TurnSpeed * turn * Time.deltaTime);
        }
        
        handleGravity();
    }
    
    private void handleGravity()
    {
        if (!_characterController.isGrounded)
        {
            _fallingSpeed += Time.deltaTime;
            _characterController.Move(transform.up * _fallingSpeed * Gravity * Time.deltaTime);
        }
        else
        {
            _fallingSpeed = 0f;
        }
    }

}
