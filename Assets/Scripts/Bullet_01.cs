using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_01 : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lifeSpan;
    private float _spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        _spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * _bulletSpeed * Time.deltaTime);
        LifeSpan();
    }

    void LifeSpan()
    {
        if (Time.time >= _spawnTime + _lifeSpan)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
