using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private GameObject ObjectOverlayCanvas;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ObjectOverlayCanvas.SetActive(false);
        }
    }

    private void OnMouseDown() {
        if (tag == "Typewriter") {
            ObjectOverlayCanvas.SetActive(true);
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