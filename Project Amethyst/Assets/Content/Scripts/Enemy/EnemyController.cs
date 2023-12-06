using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemySO Enemy;

    public Transform Player;
    public Transform Target;

    private NavMeshAgent _agent;
    private Animator _animator;
    public float Range = 5f;
    public float AttackRange = 1f;

    private float _attackRange;

    public bool _inAttackRange;

    public bool _inPlayerRange;

    public bool _canAttack;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _agent.SetDestination(Target.position);
    }

    private void FixedUpdate()
    {
        Collider[] hitFence = Physics.OverlapSphere(transform.position, Range, 1 << LayerMask.NameToLayer("Destructible"));

        _animator.SetFloat("Speed", _agent.velocity.magnitude / _agent.speed);

        _inPlayerRange = Physics.CheckSphere(transform.position, Range, 1 << LayerMask.NameToLayer("Player"));

        if (hitFence.Length != 0)
        {
            Chase(hitFence[0].transform, 1 << LayerMask.NameToLayer("Destructible"));
        }
        else if (_inPlayerRange)
        {
            Chase(Player, 1 << LayerMask.NameToLayer("Player"));
        }
    }

    private void Chase(Transform target, int layerMask)
    {
        if (!_canAttack)
        {
            _agent.SetDestination(Player.position);
        }

        _inAttackRange = Physics.CheckSphere(transform.position, AttackRange, layerMask);

        if (_inAttackRange)
        {
            _canAttack = true;
            Attack(target, layerMask);
        }
    }

    private void Attack(Transform target, int layerMask)
    {
        transform.LookAt(Player.position);

        if (_canAttack)
        {
            StartCoroutine(AttackCooldown(target, layerMask));
        }
    }
    
    private IEnumerator AttackCooldown(Transform target, int layerMask)
    {
        _canAttack = false;

        if (layerMask == 1 << LayerMask.NameToLayer("Player"))
        {
            PlayerHealth.Instance.ChangeHealth(-Enemy.Damage);
            Debug.Log("Hit Player");
        }
        else
        {
            target.gameObject.GetComponent<DestructibleFence>().Break();
            Debug.Log("Hit Fence");
        }

        yield return new WaitForSeconds(1f);

        _canAttack = true;
    }
}