using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawn;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "sea")
        {
            transform.position = respawn.transform.position;
        }
        
    }
}
