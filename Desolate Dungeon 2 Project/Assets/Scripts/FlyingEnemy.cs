using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{


    public GameObject player;
    private Transform playerRb;
    private Vector3 currentPos;
    public float distance;
    public float speed;

    void Start()
    {
        playerRb = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
    }
   

    void Update()
    {
        if (Vector2.Distance(transform.position, playerRb.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerRb.position, speed * Time.deltaTime);
        }
        else
        {
            if (Vector2.Distance(transform.position, currentPos) <=0)
            {

            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, currentPos, speed * Time.deltaTime);
                 
            }

        }

    }




}
