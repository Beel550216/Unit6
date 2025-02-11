using UnityEngine;

public class treasure : MonoBehaviour
{
    //public GameObject newTriggerObject;
    public GameObject treasureChest;
    public GameObject cross;

    public GameObject text;
    //ThirdPersonMovement playerScript; 

    private void Start()
    {
        //playerScript = gameObject.GetComponent<ThirdPersonMovement>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "cross")
        {
            if (treasureChest.gameObject.activeSelf == false)
            {
                treasureChest.SetActive(true);

                print("Treasure has been found!");
            }

            if (cross.gameObject.activeSelf == true)
            {
                cross.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (text.gameObject.activeSelf == true)
            {
                text.SetActive(false);
            }
        }
    }
}
