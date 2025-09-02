using UnityEngine;
using UnityEngine.InputSystem;

public class Spaceship : MonoBehaviour {
    private Rigidbody2D _rigidbody;
    
    private Vector2 _direction;
    [SerializeField] private float speed;

    private bool _isShooting;
    private float _lastShotTime;
    private const float Cooldown = 0.7f;
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private Transform gunTransform;
    
    private void Awake() {
        _rigidbody = transform.GetComponent<Rigidbody2D>();
        _lastShotTime = Time.time;
    }

    private void Update() {
        if (_isShooting) {
            Attack();
        }
    }
    
    private void FixedUpdate() {
        Movement();
    }

    private void OnMove(InputValue inputValue) {
        _direction = inputValue.Get<Vector2>();
    }

    private void Movement() {
        _rigidbody.linearVelocity = _direction * (speed * Time.deltaTime);
    }

    private void OnAttack(InputValue inputValue) {
        _isShooting = inputValue.isPressed;
    }

    private void Attack() {
        if (!(Time.time - _lastShotTime >= Cooldown)) {
            return;
        }
        
        Instantiate(ammoPrefab, gunTransform.position, Quaternion.identity);
        _lastShotTime = Time.time;
    }
}
