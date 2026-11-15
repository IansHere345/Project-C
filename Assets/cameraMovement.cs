using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public Transform player;
    void LateUpdate () { //LateUpdate runs after normal Updates, so it can follow the player without jittering.
        transform.position = player.transform.position + new Vector3(0, 2f, -8);
    }
}
//Source Used: https://stackoverflow.com/questions/65816546/unity-camera-follows-player-script