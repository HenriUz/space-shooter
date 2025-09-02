using UnityEngine;

public class Ammo : MonoBehaviour {
    private Rigidbody2D _rigidbody;
    
    [SerializeField] private float speed;

    private void Awake() {
        _rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    private void Start() {
        Movement();
    }

    private void Movement() {
        _rigidbody.AddForceX(speed, ForceMode2D.Impulse);
    }
}
