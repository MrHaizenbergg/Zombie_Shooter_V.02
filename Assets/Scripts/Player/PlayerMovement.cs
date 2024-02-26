using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Camera _cam;
    private FieldOfView _fieldOfView;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Joystick _joystickRotation;

    private Rigidbody2D _rb;
    private Animator _anim;
    private Vector2 _movementInput;
    private Vector2 _lookInput;
    private Vector2 _smoothetMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Vector2 mousePos;
    private Vector2 _joysRot;
    private Vector3 _lastAngle;
    private float _horizontalMove;
    private float _verticalMove;

    private bool isPC;
    private bool isAndroid;

    public bool isAttack;

    private void Awake()
    {
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _fieldOfView = FindObjectOfType<FieldOfView>();
        _joystick = FindObjectOfType<VariableJoystick>();
        _joystickRotation = FindObjectOfType<FixedJoystick>();

        //if (Application.platform == RuntimePlatform.WindowsPlayer)
        //{
        //    isPC = true;
        //    isAndroid = false;
        //    Debug.Log("PC");
        //}
        //else if (Application.platform == RuntimePlatform.WindowsEditor)
        //{
        //    isPC = true;
        //    isAndroid = false;
        //    Debug.Log("isEditor");
        //}

        if (Application.isMobilePlatform)
        {
            isAndroid = true;
            isPC = false;
            Debug.Log("Android");
        }
        else
        {
            isPC = true;
            isAndroid = false;
            Debug.Log("PC");
        }

        //#if UNITY_WEBGL
        //               isPC = true;
        //            isAndroid = false;
        //            Debug.Log("PC");      
        //#endif
        //#if UNITY_ANDROID
        //        isAndroid = true;
        //        isPC = false;
        //        Debug.Log("Android");
        //#endif

    }

    private void FixedUpdate()
    {
        if (isPC)
        {
            RotationMouse();
            SetPlayerVelocity();
            SetAnimation();
        }

        if (isAndroid)
        {
            SetPlayerVelocityJoystick();
            RotationJoystick();
            SetAnimationAndroid();
        }

        _fieldOfView.SetOrigin(transform.position);

        //RotationInput();
    }

    private void SetAnimationAndroid()
    {
        bool isMovingJoystick = _joystick.Direction != Vector2.zero;
        _anim.SetBool("isMoving", isMovingJoystick);
    }

    private void SetAnimation()
    {
        bool isMoving = _movementInput != Vector2.zero;
        _anim.SetBool("isMoving", isMoving);
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void RotationJoystick()
    {
        //_joysRot = _joystickRotation.Direction;


        if (_joystickRotation.Direction != Vector2.zero)
        {
            //float angle = Mathf.Atan2(_joysRot.y, _joysRot.x) * Mathf.Rad2Deg;
            float xAxis = _joystickRotation.Horizontal;
            float yAxis = _joystickRotation.Vertical;
            float zAxis = Mathf.Atan2(xAxis, yAxis) * Mathf.Rad2Deg;
            var targetRot = new Vector3(0f, 0f, -zAxis);
            transform.eulerAngles = targetRot;
            //_rb.rotation = angle;
            _lastAngle = targetRot;
        }
        else
        {
            transform.eulerAngles = _lastAngle;
            //_rb.rotation = _lastAngle;
        }

        //_rb.rotation = angle;
        //lookDir = lookDir.normalized;
        float n = Mathf.Atan2(_joysRot.y, _joysRot.x) * Mathf.Rad2Deg + 33f;
        if (n < 0) n += 360;
        _fieldOfView.SetAimDirection(n);
    }

    private void RotationMouse()
    {
        mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = angle;
        //lookDir = lookDir.normalized;
        float n = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 33f;
        if (n < 0) n += 360;
        _fieldOfView.SetAimDirection(n);
    }

    private void SetPlayerVelocity()
    {
        if (isAttack)
            return;

        _smoothetMovementInput = Vector2.SmoothDamp(_smoothetMovementInput, _movementInput, ref _movementInputSmoothVelocity, 0.1f);
        _rb.velocity = _smoothetMovementInput * _speed;

    }

    private void SetPlayerVelocityJoystick()
    {
        //_horizontalMove = _joystick.Horizontal;
        if (isAttack)
            return;

        if (_joystick.Horizontal >= .2f)
        {
            _horizontalMove = _speed;
        }
        else if (_joystick.Horizontal <= -.2f)
        {
            _horizontalMove = -_speed;
        }
        else
            _horizontalMove = 0f;

        if (_joystick.Vertical >= .2f)
        {
            _verticalMove = _speed;
        }
        else if (_joystick.Vertical <= -.2f)
        {
            _verticalMove = -_speed;
        }
        else
            _verticalMove = 0f;

        //_verticalMove = _joystick.Vertical;

        _smoothetMovementInput = Vector2.SmoothDamp(_smoothetMovementInput, new Vector2(_horizontalMove, _verticalMove), ref _movementInputSmoothVelocity, 0.1f);
        _rb.velocity = _smoothetMovementInput;

    }
}
