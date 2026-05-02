using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string nextSceneName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Player2D player = col.GetComponent<Player2D>();

            if (player.hasKey)
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.Log("��ͧ�աحᨡ�͹!");
            }
        }
    }
}