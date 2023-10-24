using UnityEngine;

public enum EnemyType
{

}

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Object/Enemy")]
public class EnemySO : ScriptableObject
{
    [Header("Prefab")]
    public GameObject Prefab;

    [Header("Core Information")]
    public string Name;
    public EnemyType Type;

    [Header("Main Stats")]
    public int MaxHealth;
}