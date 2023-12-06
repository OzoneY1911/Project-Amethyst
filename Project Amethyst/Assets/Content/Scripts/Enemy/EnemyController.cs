using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemySO Enemy;

    public Transform Player;
    public Transform Target;

    private NavMeshAgent _agent;
    private Animator _animator;
    public float Range = 2f;

    public bool check1 = true;
    public bool check2 = true;
    public bool check3 = true;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, Range, 1 << LayerMask.NameToLayer("Destructible"));

        //if (Physics.CheckSphere(transform.position, Range, 1 << LayerMask.NameToLayer("Player")))
        //{
                _agent.SetDestination(Player.position);
        _animator.SetFloat("Speed", _agent.velocity.magnitude / _agent.speed);
        //}
        /*else if (Physics.CheckSphere(transform.position, Range, 1 << LayerMask.NameToLayer("Destructible")))
        {
            if (check1)
            {
                check1 = false;
                check2 = true;
                check3 = true;
                _agent.SetDestination(hitColliders[0].gameObject.transform.position);
                Debug.Log("HI2");
            }
        }*/
        /*else
            {
            if (check3)
            {
                check3 = false;
                check2 = true;
                check1 = true;
                _agent.SetDestination(Target.position);
                Debug.Log("HI3");
            }
        }*/
    }
}