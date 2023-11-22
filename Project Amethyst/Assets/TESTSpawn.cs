using UnityEngine;

public class TESTSpawn : SingletonMono<TESTSpawn>
{
    public GameObject Spider;
    public Transform SpawnPoint;

    protected override void Awake()
    {
        base.Awake();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(Spider, SpawnPoint);
        }
    }
}