using UnityEngine;

public class Dagger : MonoBehaviour
{

    Rigidbody2D daggerRb;
    [SerializeField] float daggerSpeed;

    void Start()    
    {
        
        daggerRb = GetComponent<Rigidbody2D>();
        daggerRb.linearVelocity = transform.right * daggerSpeed;
      


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dagger Destroyer"))
        {
            Destroy(gameObject);
        }
  }


}
