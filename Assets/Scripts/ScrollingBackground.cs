using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
    private Material _backgroundMaterial;
    private Vector2 _offset;
    
    [SerializeField] private float speed;

    private void Awake() {
        _backgroundMaterial = transform.GetComponentInChildren<SpriteRenderer>().material;
    }

    private void Update() {
        _offset.x += speed * Time.deltaTime;
        _backgroundMaterial.mainTextureOffset = _offset;
    }
}
