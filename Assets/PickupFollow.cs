using UnityEngine;

public class PickupFollow : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 3, 0);

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // ปิด Collider ไม่ให้ชนซ้ำ
            GetComponent<Collider2D>().enabled = false;

            // ทำให้ของติด Player
            transform.SetParent(col.transform);

            // ตั้งตำแหน่งลอยเหนือหัว
            transform.localPosition = offset;
        }
    }
}
