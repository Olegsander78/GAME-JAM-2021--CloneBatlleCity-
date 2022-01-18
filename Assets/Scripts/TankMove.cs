using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankMove : MonoBehaviour
{
    public Track TrackLeft;
    public Track TrackRight;

    public KeyCode KeyMoveForward;
    public KeyCode KeyMoveReverse;
    public KeyCode KeyRotateRight;
    public KeyCode KeyRotateLeft;

    public bool IsEnemy;

    bool _moveForward = false;
    bool _moveReverse = false;
    float _moveSpeed = 0f;
    float _moveSpeedReverse = 0f;    
    float _moveAcceleration = 0.1f;
    float _moveDeceleration = 0.20f;
    float _moveSpeedMax = 2.5f;

    [Header("Enemy")]
    public float SpeedEnemyTank = 100f;    
    public Transform TankEnemyTransform;
    public float MinMoveTime = 0.5f;
    public float MaxMoveTime = 5.5f;
    private Rigidbody2D _bodyRB;
    private Vector2 _moveDirection;
    private Vector3 _rotation;
    private int _move;


    void Start()
    {
        if (IsEnemy)
        {            
            _move = 0;
            trackStop();
            _bodyRB = GetComponent<Rigidbody2D>();
            StartCoroutine(WaitMove(Random.Range(MinMoveTime, MaxMoveTime)));            
        }
    } 

    IEnumerator WaitMove(float t)
    {
        _move = Random.Range(0, 4);
        yield return new WaitForSeconds(t);
        StartCoroutine(WaitMove(Random.Range(MinMoveTime, MaxMoveTime)));
    }

    void Update()
    {
        if (!IsEnemy)
        {
            if (Input.GetKeyDown(KeyRotateLeft))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, transform.rotation.eulerAngles.z + 90f));
            }
            if (Input.GetKeyDown(KeyRotateRight))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, transform.rotation.eulerAngles.z - 90f));
            }

            _moveForward = (Input.GetKeyDown(KeyMoveForward)) ? true : _moveForward;
            _moveForward = (Input.GetKeyUp(KeyMoveForward)) ? false : _moveForward;
            if (_moveForward)
            {
                _moveSpeed = (_moveSpeed < _moveSpeedMax) ? _moveSpeed + _moveAcceleration : _moveSpeedMax;
            }
            else
            {
                _moveSpeed = (_moveSpeed > 0) ? _moveSpeed - _moveDeceleration : 0;
            }
            transform.Translate(0f, _moveSpeed * Time.deltaTime, 0f);

            _moveReverse = (Input.GetKeyDown(KeyMoveReverse)) ? true : _moveReverse;
            _moveReverse = (Input.GetKeyUp(KeyMoveReverse)) ? false : _moveReverse;
            if (_moveReverse)
            {
                _moveSpeedReverse = (_moveSpeedReverse < _moveSpeedMax) ? _moveSpeedReverse + _moveAcceleration : _moveSpeedMax;
            }
            else
            {
                _moveSpeedReverse = (_moveSpeedReverse > 0) ? _moveSpeedReverse - _moveDeceleration : 0;
            }
            transform.Translate(0f, _moveSpeedReverse * Time.deltaTime * -1f, 0f);


            if (_moveForward | _moveReverse)
            {
                trackStart();
            }
            else
            {
                trackStop();
            }
        }
        if (IsEnemy)
        {
            switch (_move)
            {
                case 1:
                    _moveDirection = new Vector2(0, 1);
                    _rotation = new Vector3(0, 0, 0);
                    trackStart();
                    break;

                case 2:
                    _moveDirection = new Vector2(0, -1);
                    _rotation = new Vector3(0, 0, 180);
                    trackStart();
                    break;

                case 3:
                    _moveDirection = new Vector2(-1, 0);
                    _rotation = new Vector3(0, 0, 90);
                    trackStart();
                    break;

                case 4:
                    _moveDirection = new Vector2(1, 0);
                    _rotation = new Vector3(0, 0, -90);
                    trackStart();
                    break;

                default:
                    _moveDirection = new Vector2(0, 0);                    
                    trackStop();
                    break;
            }
            TankEnemyTransform.localRotation = Quaternion.Euler(_rotation);
        }
    }
    void FixedUpdate()
    {
        if (IsEnemy)
        {
            _bodyRB.AddForce(_moveDirection * SpeedEnemyTank);

            if (Mathf.Abs(_bodyRB.velocity.x) > SpeedEnemyTank / 100f)
            {
                _bodyRB.velocity = new Vector2(Mathf.Sign(_bodyRB.velocity.x) * SpeedEnemyTank / 100f, _bodyRB.velocity.y);
            }
            if (Mathf.Abs(_bodyRB.velocity.y) > SpeedEnemyTank / 100f)
            {
                _bodyRB.velocity = new Vector2(_bodyRB.velocity.x, Mathf.Sign(_bodyRB.velocity.y) * SpeedEnemyTank / 100f);
            }
        }
    }

    void trackStart()
    {
        TrackLeft.Animator.SetBool("isMoving", true);
        TrackRight.Animator.SetBool("isMoving", true);        
    }

    void trackStop()
    {
        TrackLeft.Animator.SetBool("isMoving", false);
        TrackRight.Animator.SetBool("isMoving", false);        
    }
}
