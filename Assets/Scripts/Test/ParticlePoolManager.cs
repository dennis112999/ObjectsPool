using UnityEngine;

public class ParticlePoolManager : PoolManager<ParticleObject>
{
    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_objectPool == null)
            {
                return;
            }

            var particle = _objectPool.Get();

            if (particle == null)
            {
                return;
            }

            particle.transform.position = transform.position;
            particle.Initialize();
        }
    }
}

