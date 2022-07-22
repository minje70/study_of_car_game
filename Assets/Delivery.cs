using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    bool hasPackage = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage) {
            hasPackage = true;
            Destroy(other.gameObject);
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Package Pick Up");
        }
        if (other.tag == "Customer" && hasPackage == true) {
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Debug.Log("kill Customer");
        }
    }
}
