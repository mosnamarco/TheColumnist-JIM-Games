using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private GameObject ObjectOverlayCanvas;
    private Collider2D[] colliders;

    private void Start() {
        colliders = FindObjectsOfType<Collider2D>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ObjectOverlayCanvas.SetActive(false);
            foreach (Collider2D collider in colliders) {
                collider.enabled = true;
            }
        }
    }

    private void OnMouseDown() {
        if (tag == "Typewriter") {
            ObjectOverlayCanvas.SetActive(true);
            foreach (Collider2D collider in colliders) {
                collider.enabled = false;
            }
        }
    }
    private void OnMouseEnter() {
        Debug.Log("Object ENTERED!");
        transform.localScale *= 1.1f;

    }

    private void OnMouseExit() {
        Debug.Log("Object EXITED!");
        transform.localScale /= 1.1f;
    }
}