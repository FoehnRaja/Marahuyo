using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Turret : MonoBehaviour
{
    private CircleCollider2D circleCollider2D;
    [SerializeField] private float attackRange = 6f;

    public Enemy CurrentEnemyTarget { get; set; }
    public TurretUpgrade TurretUpgrade { get; set; }
    public float AttackRange => attackRange;

    public static Action<Turret> OnEnemyDetect;
    private Turret _turret;

    private bool _gameStarted; 
    private List<Enemy> _enemies;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _gameStarted = true;
        _enemies = new List<Enemy>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        TurretUpgrade = GetComponent<TurretUpgrade>();
    }
    private void Update()
    {
        GetCurrentEnemyTarget();
        RotateTowardsTarget();
        circleCollider2D.radius = AttackRange;
        }
    private void GetCurrentEnemyTarget()
    {
        if (_enemies.Count <= 0)
        {
            CurrentEnemyTarget = null;
            return;
        }
        OnEnemyDetect?.Invoke(_turret);
        CurrentEnemyTarget = _enemies[0];

    }

    private void RotateTowardsTarget()
    {
        if (CurrentEnemyTarget == null)
        {
            return;
        }
            if(transform.position.x > CurrentEnemyTarget.transform.position.x)
            {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            return;
            }
        else {
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy newEnemy = other.GetComponent<Enemy>();
            _enemies.Add(newEnemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (_enemies.Contains(enemy))
            {
                _enemies.Remove(enemy);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!_gameStarted)
        {
            GetComponent<CircleCollider2D>().radius = attackRange;
             
        }

        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
