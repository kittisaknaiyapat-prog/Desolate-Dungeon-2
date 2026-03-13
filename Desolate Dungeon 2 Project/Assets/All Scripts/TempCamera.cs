using UnityEngine;

public class TempCamera : MonoBehaviour
{
    [SerializeField] Transform playerpos;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (playerpos.position.x,playerpos.position.y,transform.position.z);
    }
}
