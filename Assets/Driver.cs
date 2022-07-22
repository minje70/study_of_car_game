using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float moveSpeed = 30f;
    [SerializeField] float slowMoveSpeed = 20f;
    [SerializeField] float fastMoveSpeed = 40f;
    void Start()
    {
    }

    void Update() {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, -steerAmount);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Obstacle") {
            moveSpeed = slowMoveSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "SpeedUp") {
            moveSpeed = fastMoveSpeed;
            Destroy(other.gameObject);
        }
    }
}
