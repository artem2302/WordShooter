using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Weapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    void Start() {
        if (cam == null) {
            Debug.LogError("PlayerShoot: No camera!");
            this.enabled = false;
        }
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit _hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask)) {
                print("Shot hit " + _hit.collider.name);
            }
        }
    }
}
