using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("CameraValues")]
    [SerializeField] Vector3 offsetPlayer;
    [SerializeField] Vector3 offsetTopPos;
    [SerializeField] float smooth = 0.95f;

    [Header("CameraPosStuff")]
    [SerializeField] Transform player;
    [SerializeField] Transform cameraTopPos;
    [SerializeField] Transform cameraLookAt;
    [SerializeField] MoveToCenter MoveToCenter;
    
    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
        LookAtEnemy();
    }
    public void LookAtEnemy()
    {
        if (!MoveToCenter.followPlayer)
        {
            transform.LookAt(cameraLookAt);
            transform.position = Vector3.Lerp(transform.position, cameraTopPos.transform.position - offsetTopPos, 2.5f * Time.deltaTime);
        }
    }
    private void FollowPlayer()
    {
        if (MoveToCenter.followPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position - offsetPlayer, smooth);
            transform.LookAt(player);
        }
    }
}
