using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemySO Enemy;
    private NavMeshAgent _agent;
    private Animator _animator;

    private LayerMask _destructibleLayer;
    private LayerMask _playerLayer;

    public Transform Player;
    public Transform Target;

    public bool _inAttackRange;
    public bool _inPlayerRange;

    private float _checkRange = 5f;
    public float _attackRange = 2f;
    private bool _attacking;

    private bool _canInfiltrate;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _destructibleLayer = 1 << LayerMask.NameToLayer("Destructible");
        _playerLayer = 1 << LayerMask.NameToLayer("Player");
    }

    private void FixedUpdate()
    {
        _animator.SetFloat("Speed", _agent.velocity.magnitude / _agent.speed);

        if (_canInfiltrate)
        {

        }
        else
        {
            ChaseFence();
        }

        //_inPlayerRange = Physics.CheckSphere(transform.position, Range, 1 << LayerMask.NameToLayer("Player"));

        /*if (hitFence.Length != 0)
        {
            Chase(hitFence[0].transform, 1 << LayerMask.NameToLayer("Destructible"));
        }
        else if (_inPlayerRange)
        {
            Chase(Player, 1 << LayerMask.NameToLayer("Player"));
        }*/
    }

    private void ChaseFence()
    {
        // Check if any Fence is nearby
        Collider[] hitFence = Physics.OverlapSphere(transform.position, _checkRange, _destructibleLayer);

        // Chase Fence
        if (hitFence.Length > 0)
        {
            GameObject fence = hitFence[0].gameObject;
            float distance = (fence.transform.position - transform.position).sqrMagnitude;

            if (distance < _attackRange * _attackRange)
            {
                if (fence.GetComponent<DestructibleFence>().Health > 0)
                {
                    Attack(hitFence[0].gameObject.transform, _destructibleLayer);
                }
                else
                {
                    if (!_attacking)
                    {
                        _canInfiltrate = true;
                        _agent.SetDestination(Target.position);
                    }
                }
            }
            else
            {
                _agent.SetDestination(hitFence[0].gameObject.transform.position);
            }
        }
    }

    private void Chase(in Transform target, in int layerMask)
    {
        if (_attacking)
        {
            _agent.SetDestination(Player.position);
        }

        _inAttackRange = Physics.CheckSphere(transform.position, _attackRange, layerMask);

        if (_inAttackRange)
        {
            _attacking = false;
            Attack(target, layerMask);
        }
    }

    private void Attack(in Transform target, in int layerMask)
    {
        transform.LookAt(target.position);

        if (!_attacking)
        {
            StartCoroutine(AttackCooldown(target, layerMask));
        }
    }
    
    private IEnumerator AttackCooldown(Transform target, int layerMask)
    {
        _attacking = true;

        if (layerMask == _playerLayer)
        {
            PlayerHealth.Instance.ChangeHealth(-Enemy.Damage);
        }
        else if (layerMask == _destructibleLayer)
        {
            target.gameObject.GetComponent<DestructibleFence>().Break();
        }

        yield return new WaitForSeconds(1f);

        _attacking = false;
    }
}