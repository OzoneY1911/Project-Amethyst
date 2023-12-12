using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : EntityHealth
{
    private static PlayerCurrency _playerCurrency => PlayerCurrency.Instance;
    private Animator _animator;

    private bool _vanishing;

    private void OnEnable()
    {
        Init();
    }

    protected override void Init()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<EnemyAI>().Enemy.MaxHealth;
    }

    protected override void Die()
    {
        if (!_vanishing)
        {
            KillCounter.Instance.UpdateCounter();

            _playerCurrency.Add(_playerCurrency.CurrencyList[Random.Range(0, 3)], Random.Range(10, 20));

            GetComponent<EnemyAI>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;

            _animator.SetTrigger("Die");

            StartCoroutine(Vanish());
        }
    }

    private IEnumerator Vanish()
    {
        _vanishing = true;

        yield return new WaitForSeconds(10f);
        EnemyPool.Instance.Release(gameObject);
        EnemyPool.Instance.Get(gameObject);

        _vanishing = false;
    }
}