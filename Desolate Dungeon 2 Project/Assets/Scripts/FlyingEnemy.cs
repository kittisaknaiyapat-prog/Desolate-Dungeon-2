
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{


   
    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;

    [SerializeField] Transform playerRb;

    [SerializeField] float moveSpeed;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        

        if (player = null)
        return;
      
        if (chase == true)
        {
            Chase();
            Flip();
        }
        
            //starts in starting position
            ReturnStartPoint();
      
        
    }

    private void Chase()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, playerRb.position, moveSpeed * Time.deltaTime);


        //Detta under om jag vill lägga till mer

        if (Vector2.Distance(transform.position, playerRb.transform.position) <= 10f)
        {
            // change speed, shoot, animation
        }
        else
        {
            // reset variable
        }
    }

    private void Flip()
    {

        if (transform.position.x > playerRb.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, moveSpeed* Time.deltaTime);
    }

}
