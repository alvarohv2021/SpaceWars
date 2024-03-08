using System;
using Unity.VisualScripting;
using UnityEngine;

public class Dummie : MonoBehaviour
{
    // Referencia al jugador
    Transform player;

    // Velocidad de rotación del enemigo
    public float rotationSpeed = 5f;
    [SerializeField] private float _speed;

    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("Player");
            if (go != null)
            {
                player = go.transform;
            }
        }
        if (player == null)
            return;

        Vector2 directionToPlayer = player.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg + 90;

        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
