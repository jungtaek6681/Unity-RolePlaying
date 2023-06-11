using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpSpeed;

    private CharacterController controller;
    private Animator anim;
    private Vector3 moveDir;
    private float curSpeed;
    private float ySpeed = 0;
    private bool walk = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        moveRoutine = StartCoroutine(MoveRoutine());
        jumpRoutine = StartCoroutine(JumpRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(moveRoutine);
        StopCoroutine(jumpRoutine);
    }

    Coroutine moveRoutine;
    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            if (moveDir.sqrMagnitude <= 0)
            {
                curSpeed = Mathf.Lerp(curSpeed, 0, 0.1f);
                anim.SetFloat("MoveSpeed", curSpeed);
                yield return null;
                continue;
            }

            Vector3 fowardVec = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
            Vector3 rightVec = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;

            if (walk)
            {
                curSpeed = Mathf.Lerp(curSpeed, walkSpeed, 0.1f);
            }
            else
            {
                curSpeed = Mathf.Lerp(curSpeed, runSpeed, 0.1f);
            }

            controller.Move(fowardVec * moveDir.z * curSpeed * Time.deltaTime);
            controller.Move(rightVec * moveDir.x * curSpeed * Time.deltaTime);
            anim.SetFloat("MoveSpeed", curSpeed);

            Quaternion lookRotation = Quaternion.LookRotation(fowardVec * moveDir.z + rightVec * moveDir.x);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.2f);
            yield return null;
        }
    }

    Coroutine jumpRoutine;
    private IEnumerator JumpRoutine()
    {
        while (true)
        {
            ySpeed += Physics.gravity.y * Time.deltaTime;

            if (GroundCheck() && ySpeed < 0)
                ySpeed = -1;

            controller.Move(Vector3.up * ySpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir = new Vector3(input.x, 0, input.y);
    }

    private void OnJump(InputValue value)
    {
        if (GroundCheck())
            ySpeed = jumpSpeed;
    }

    private void OnWalk(InputValue value)
    {
        walk = value.isPressed;
    }

    private bool GroundCheck()
    {
        RaycastHit hit;
        return Physics.SphereCast(transform.position + Vector3.up * 1, 0.5f, Vector3.down, out hit, 0.5f);
    }
}
