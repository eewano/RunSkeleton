using UnityEngine;

public class DebugController : MonoBehaviour {

    private PlayerController playerController;

    void Awake() {
        playerController = GetComponent<PlayerController>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerController.PushLeftDown();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerController.PushLeftUp();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerController.PushRightDown();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerController.PushRightUp();
        }
    }
}