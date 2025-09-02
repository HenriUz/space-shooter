using UnityEngine;

public class MeteorController : MonoBehaviour {
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    [SerializeField] private float speed;
    
    private void Awake() {
        _rigidbody = transform.GetComponent<Rigidbody2D>();
        _animator = transform.GetComponentInChildren<Animator>();
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        _animator.enabled = true;
        Destroy(gameObject, 0.5f);
    }

    private void Movement() {
        _rigidbody.AddForceX(speed * -1, ForceMode2D.Impulse);
    }
}
