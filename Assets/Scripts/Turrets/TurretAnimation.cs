using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretAnimation : MonoBehaviour
{
    private Animator _animator;
    private Turret _turret;
    

    private void Start()
    {
        _animator = GetComponent<Animator>();
       
        _turret = GetComponent<Turret>();
    }

    private void PlayAtkAnimation()
    {
        _animator.SetTrigger("Atk");
    }

    private float GetCurrentAnimationLenght()
    {
        float animationLenght = _animator.GetCurrentAnimatorStateInfo(0).length;
        return animationLenght;
    }

    private IEnumerator PlayAtk()
    {
        PlayAtkAnimation();
        yield return new WaitForSeconds(GetCurrentAnimationLenght() + 0.3f);
    }

    private void EnemyDetect(Turret turret)
    {
        if(_turret.CurrentEnemyTarget != null)
        {
            StartCoroutine(PlayAtk());
        }
    }
    private void OnEnable()
    {
        Turret.OnEnemyDetect += EnemyDetect;
    }

    private void OnDisable()
    {
        Turret.OnEnemyDetect -= EnemyDetect;
    }

}
