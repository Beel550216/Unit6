using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawn;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawn.transform.position;
        }
    }

}
