using UnityEngine;

public class BreakBox : MonoBehaviour
{
    public GameObject brokenBoxPrefab; // ใส่ Prefab ของกล่องที่แตก
    public float explosionForce = 300f;
    public float explosionRadius = 2f;

    void OnMouseDown() // ตรวจจับการคลิกที่กล่อง
    {
        Break();
    }

    void Break()
    {
        GameObject brokenBox = Instantiate(brokenBoxPrefab, transform.position, transform.rotation); // สร้างกล่องแตก
        foreach (Rigidbody rb in brokenBox.GetComponentsInChildren<Rigidbody>())
        {
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius); // เพิ่มแรงกระจาย
        }
        Destroy(gameObject); // ลบกล่องเดิมออก
    }
}