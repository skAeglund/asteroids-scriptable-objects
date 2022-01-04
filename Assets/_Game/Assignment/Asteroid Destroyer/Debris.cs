using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    private Rigidbody2D _rB;
    private SpriteRenderer _spriteRenderer;
    private float force = 100;
    private float timer = 0;
    private float lifetime = 4;
    private Color startColor;

    void Start()
    {
        _rB = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        startColor = _spriteRenderer.color;

        Vector2 randomDirection = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)).normalized;
        _rB.AddForce(randomDirection * force);
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        timer += Time.deltaTime;
        FadeColor();
    }

    private void FadeColor()
    {
        float age = timer / lifetime;

        _spriteRenderer.color = Color.Lerp(startColor, Color.clear, age);
    }
}
