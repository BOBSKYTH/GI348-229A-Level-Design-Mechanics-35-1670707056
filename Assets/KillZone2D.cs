using UnityEngine;

public class KillZone2D : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.transform.position = new Vector2(-18,3
                );
        }
    }
}
