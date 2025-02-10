using UnityEngine;

public class Button : MonoBehaviour
{
    public void Quit()
    {
        if (gameObject.tag == "Quit")
        {
            Application.Quit();
            print("left game");
        }
    }

}
