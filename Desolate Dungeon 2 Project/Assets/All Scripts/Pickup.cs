using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collosion)
    {
        if (collosion.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
           // FindFirstObjectByType<AudioManager>().PlaySound(1);

        }
    }
}
