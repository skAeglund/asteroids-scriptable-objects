using UnityEngine;
using Asteroids;

public class AsteroidDestroyer : MonoBehaviour
{
    [SerializeField] private AsteroidRuntimeSet _asteroidRuntimeSet;
    [SerializeField] private GameObject _asteroidDebrisPrefab;

    public void DestroyAsteroid(int id)
    {
        Asteroid asteroidToDestroy =_asteroidRuntimeSet.Items.Find(x => x.GetInstanceID() == id);
        if (asteroidToDestroy == null) return;

        Vector3 asteroidSize = asteroidToDestroy.Shape.localScale;

        SpawnDebris(asteroidSize * 0.33f, 3, asteroidToDestroy.transform.position);
        Destroy(asteroidToDestroy.gameObject);
    }

    private void SpawnDebris(Vector3 size, int count, Vector3 position)
    {
        for (int i = 0; i < count; i++)
        {
            var newAsteroid = Instantiate(_asteroidDebrisPrefab, position, Quaternion.identity);
            newAsteroid.transform.Find("Asteroid_Size").transform.localScale = size;
        }
    }
}
