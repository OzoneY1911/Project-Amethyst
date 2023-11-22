using UnityEngine;

public class SingletonClass : SingletonMono<SingletonClass>
{
    protected override void Awake()
    {
        base.Awake();
        
    }
}