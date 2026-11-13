using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float _MovementSpeed = 10f;
    [SerializeField] float _Accleration = 40f;
    [SerializeField] float _JumpValue = 3f;
    [SerializeField] float _MinMovementBound = -8.5f;
    [SerializeField] float _MaxMovementBound = 8.5f;

    [Header("Jump Check")]
    [SerializeField] float _GroundCheckDistance = .1f;
    [SerializeField] Vector2 _GroundCheckSize = new Vector2(1f, .1f);
    [SerializeField] bool _JumpRequested;
    [SerializeField] Transform _GroundCheckPoint;
    [SerializeField] LayerMask _GroundLayer;
    InputAction _MoveAction;
    InputAction _JumpAction;
    Vector2 _MovementInput;
    Rigidbody2D _RB;
    RaycastHit2D _GroundCheck;

    void OnEnable() => EventManager._IncreaseJumpHeight += IncreaseJumpHeight;
    void OnDisable() => EventManager._IncreaseJumpHeight -= IncreaseJumpHeight;

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

        ClampPosition();

    }

    private void ClampPosition()
    {
        Vector2 _PlayerClampPosition = _RB.position;

        _PlayerClampPosition.x = Mathf.Clamp(_PlayerClampPosition.x, _MinMovementBound, _MaxMovementBound);

        _RB.position = _PlayerClampPosition;
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
        _GroundCheck = Physics2D.BoxCast(_GroundCheckPoint.position, _GroundCheckSize, 0f, Vector2.down,_GroundCheckDistance,_GroundLayer);

        //_GroundCheck = Physics2D.Raycast(_GroundCheckPoint.position, Vector2.down, _GroundCheckDistance, _GroundLayer);
        //Debug.DrawRay(_GroundCheckPoint.position, new Vector2(0,-_GroundCheckDistance), Color.red);
    }

    void OnDrawGizmos()
    {
        if(_GroundCheckPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_GroundCheckPoint.position + (Vector3.down * _GroundCheckDistance), _GroundCheckSize);
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

    public void IncreaseJumpHeight(float _Amount)
    {
        _JumpValue += _Amount;
    }
}
