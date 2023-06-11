using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] Weapon weapon;

    private Animator anim;
    private PlayerMover mover;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mover = GetComponent<PlayerMover>();
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    private void OnAttack(InputValue value)
    {
        Attack();
    }

    public void StartAttack()
    {
        mover.enabled = false;
    }

    public void EndAttack()
    {
        mover.enabled = true;
    }

    public void EnableWeapon()
    {
        weapon.EnableWeapon();
    }

    public void DisableWeapon()
    {
        weapon.DisableWeapon();
    }
}
