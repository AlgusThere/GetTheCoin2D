using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float _MovementSpeed = 10f;
    [SerializeField] float _Accleration = 40f;
    [SerializeField] float _JumpValue = 3f;

    [Header("Jump Check")]
    [SerializeField] float _GroundCheckDistance = .1f;
    [SerializeField] bool _JumpRequested;
    [SerializeField] Transform _GroundCheckPoint;
    [SerializeField] LayerMask _GroundLayer;

    InputAction _MoveAction;
    InputAction _JumpAction;
    Vector2 _MovementInput;
    Rigidbody2D _RB;
    RaycastHit2D _GroundCheck;

    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
        _MoveAction = InputSystem.actions.FindAction("Move");
        _JumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        _MovementInput = _MoveAction.ReadValue<Vector2>();

        if(_JumpAction.WasPressedThisFrame())
            _JumpRequested = true;
    }

    void FixedUpdate()
    {
        Movement();

        GroundCheck();

        Jump();

    }

    void Movement()
    {
        float _TargetSpeed = _MovementInput.x * _MovementSpeed;

        Vector2 _Velocity = _RB.linearVelocity;

        _Velocity.x = Mathf.MoveTowards(_Velocity.x, _TargetSpeed, _Accleration * Time.fixedDeltaTime);

        _RB.linearVelocity = _Velocity;
    }

    void GroundCheck()
    {
        _GroundCheck = Physics2D.Raycast(_GroundCheckPoint.position, Vector2.down, _GroundCheckDistance, _GroundLayer);
        
        Debug.DrawRay(_GroundCheckPoint.position, new Vector2(0,-_GroundCheckDistance), Color.red);
    }

    void Jump()
    {
        if (_GroundCheck)
        {
            if(_JumpRequested)
                _RB.AddForce(Vector2.up * _JumpValue, ForceMode2D.Impulse);
        }
        _JumpRequested = false;
    }
}
