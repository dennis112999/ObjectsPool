using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ParticleObject : MonoBehaviour, IPooledObject<ParticleObject>
{
    private IObjectPool<ParticleObject> _objectPool;
    public IObjectPool<ParticleObject> ObjectPool
    {
        set => _objectPool = value;
    }
    public void Initialize()
    {
        var particle = GetComponent<ParticleSystem>();
        particle.Play();
        var lifetime = particle.main.startLifetime.constantMax;
        StartCoroutine(DelayDeactivation(lifetime));
    }

    private IEnumerator DelayDeactivation(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Deactivate();
    }

    public void Deactivate()
    {
        _objectPool.Release(this);
    }
}
