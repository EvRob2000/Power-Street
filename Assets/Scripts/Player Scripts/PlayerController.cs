using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[SelectionBase]

public class PlayerController : MonoBehaviour
{
    #region Enums
    private enum Directions { UP, DOWN, LEFT, RIGHT }
    #endregion

    #region Editor Data
    [Header("Movement Attributes")]
    [SerializeField] float _moveSpeed = 50f;

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;
    #endregion

    #region Internal Data
    private Vector2 _moveDir = Vector2.zero;
    private Directions _facingDirection = Directions.RIGHT;

    private readonly int _animMoveRight = Animator.StringToHash("Anim_Player_Move_Right");
    private readonly int _animIdleRight = Animator.StringToHash("Anim_Player_Idle_Right");

    private readonly int _animHitRight = Animator.StringToHash("Anim_Player_Hit_Right");

    private readonly int _animMoveUp = Animator.StringToHash("Anim_Player_Move_Up");
    private readonly int _animIdleUp = Animator.StringToHash("Anim_Player_Idle_Up");

    private readonly int _animHitUp = Animator.StringToHash("Anim_Player_Hit_Up");

    private readonly int _animMoveDown = Animator.StringToHash("Anim_Player_Move_Down");
    private readonly int _animIdleDown = Animator.StringToHash("Anim_Player_Idle_Down");

    private readonly int _animHitDown = Animator.StringToHash("Anim_Player_Hit_Down");
    #endregion

    #region Tick
    private void Update()
    {
        GatherInput();
        CalculateFacingDirection();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        MovementUpdate();
    }
    #endregion

    #region Input Logic
    private void GatherInput()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");

        Debug.Log(_moveDir);
    }
    #endregion

    #region Movement Logic
    private void MovementUpdate()
    {
        _rb.velocity = _moveDir * _moveSpeed * Time.fixedDeltaTime;
    }
    #endregion

    #region Animation Logic
    private void CalculateFacingDirection()
    {
        if (_moveDir.x > 0) // Moving Right
        {
            _facingDirection = Directions.RIGHT;
        }
        else if (_moveDir.x < 0) // Moving Left
        {
            _facingDirection = Directions.LEFT;
        }

        if (_moveDir.y > 0) // Moving Up
        {
            _facingDirection = Directions.UP;
        }
        else if (_moveDir.y < 0) // Moving Down
        {
            _facingDirection = Directions.DOWN;
        }
    }

    private void UpdateAnimation()
    {
        if (_facingDirection == Directions.LEFT)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_facingDirection == Directions.RIGHT)
        {
            _spriteRenderer.flipX = false;
        }

        var isMoving = _moveDir.SqrMagnitude() > 0;
        var animation = _animMoveRight;

        switch (_facingDirection)
        {
            case Directions.UP:
                animation = isMoving ? _animMoveUp : _animIdleUp;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    animation = _animHitUp;
                }
                break;
            case Directions.DOWN:
                animation = isMoving ? _animMoveDown : _animIdleDown;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    animation = _animHitDown;
                }
                break;
            case Directions.LEFT:
            case Directions.RIGHT:
            default:
                animation = isMoving ? _animMoveRight : _animIdleRight;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    animation = _animHitRight;
                }
                break;
        }

        _animator.CrossFade(animation, 0);
    }
    #endregion
}