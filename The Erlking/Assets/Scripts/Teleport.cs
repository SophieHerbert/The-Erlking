using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTo;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered");
            // Get the player's transform
            if (other.TryGetComponent(out PlayerController controller) == true)
            {
                controller.MoveCharacter(teleportTo);
            }
        }
    }
}
