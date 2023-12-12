using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _target;

    [SerializeField] private float _initCheck = 10f;
    [SerializeField] private float _checkRange = 5f;
    [SerializeField] private float _attackRange = 2f;

    public EnemySO Enemy;

    private NavMeshAgent _agent;
    private Animator _animator;
    private LayerMask _destructibleLayer;
    private LayerMask _playerLayer;
    private LayerMask _targetLayer ;

    private bool _infiltrate;
    private bool _playerDetected;
    private bool _attacking;

    private Collider[] _hitFence = new Collider[1];

    public Collider _targetFence
    {
        get
        {
            return _hitFence[0];
        }
    }

    private void OnEnable()
    {
        _infiltrate = false;
        _playerDetected = false;
        _attacking = false;

        _hitFence[0] = null;
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _destructibleLayer = 1 << LayerMask.NameToLayer("Destructible");
        _playerLayer = 1 << LayerMask.NameToLayer("Player");
        _playerLayer = 1 << LayerMask.NameToLayer("Target");

        _target = GameObject.FindWithTag("Target").transform;
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        _animator.SetFloat("Speed", _agent.velocity.magnitude / _agent.speed);

        // Chase if not attacking
        if (!_attacking)
        {
            // Check if inside Player territory
            if (_infiltrate)
            {
                // Check if Player is seen
                if (_playerDetected)
                {
                    ChasePlayer();
                }
                else
                {
                    ChaseTarget();
                }
            }
            else
            {
                ChaseFence();
            }
        }
    }

    private void ChaseFence()
    {
        // Check if any Fence is nearby
        _hitFence = Physics.OverlapSphere(transform.position, _initCheck, _destructibleLayer, QueryTriggerInteraction.Collide);

        // Chase Fence
        if (_hitFence.Length > 0)
        {
            GameObject fence = _hitFence[0].gameObject;
            float distance = (fence.transform.position - transform.position).sqrMagnitude;

            if (distance < _attackRange * _attackRange)
            {
                if (fence.GetComponent<DestructibleFence>().Health > 0)
                {
                    Attack(_hitFence[0].gameObject.transform, _destructibleLayer);
                }
                else
                {
                    if (!_attacking)
                    {
                        _infiltrate = true;
                        ChaseTarget();
                    }
                }
            }
            else
            {
                _agent.SetDestination(_hitFence[0].gameObject.transform.position);
            }
        }
    }

    private void ChaseTarget()
    {
        float distance = (_player.transform.position - transform.position).sqrMagnitude;
        float targetDistance = (_target.transform.position - transform.position).sqrMagnitude;

        if (distance < _checkRange * _checkRange)
        {
            _playerDetected = true;
        }
        else
        {
            if (targetDistance < _attackRange * _attackRange)
            {
                Attack(_target.transform, _targetLayer);
            }
            else
            {
                _agent.SetDestination(_target.position);
            }
        }
    }

    private void ChasePlayer()
    {
        float distance = (_player.transform.position - transform.position).sqrMagnitude;

        if (distance < _attackRange * _attackRange)
        {
            Attack(_player.transform, _playerLayer);
        }
        else
        {
            _agent.SetDestination(_player.transform.position);
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
            _animator.SetTrigger("Attack");
        }
        else if (layerMask == _destructibleLayer)
        {
            _animator.SetTrigger("Ram");
        }
        else if (layerMask == _targetLayer)
        {
            _animator.SetTrigger("RamTarget");
        }

        yield return new WaitForSeconds(3f);

        _attacking = false;
    }
}