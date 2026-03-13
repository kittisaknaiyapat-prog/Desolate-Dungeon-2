using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    InputAction interactAction;


    [Header("Settings")]
    [SerializeField] private GameObject enemyPrefab;   
    [SerializeField] private GameObject powerUpPrefab;  

    private bool isOpened = false;

    public Transform player;


    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        // kollar om player har öppnat eller inte öppnat chesten
        if (other.CompareTag("Player") && !isOpened)
        {
            OpenChest();
        }
    }

 
    void StartOpen()
    {
        if (interactAction.WasPerformedThisFrame())
        {
            Debug.Log("You pressed E)");


        }
    }

    void Update()
    {

        StartOpen();

    }

    private void OpenChest()
    {
        isOpened = true;
        //  kan spela animation/Ljud



        // Generera 50/50 chans (0 or 1)
        int randomChance = Random.Range(0, 2);

        if (randomChance == 0)
        {
            // Spawn Enemy
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Debug.Log("Enemy Spawned!");
        }
        else
        {
            // Drop Power-Up
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            Debug.Log("PowerUp Dropped!");
        }

        // Optional: Destroy the chest object or change its sprite to 'opened'
        Destroy(gameObject, 0.1f);
    }


   
}








