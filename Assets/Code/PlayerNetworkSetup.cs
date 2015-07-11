using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour
{
	[SerializeField] CharacterMovement mover;
    [SerializeField] Camera follower;

	void Start ()
    {
        if(isLocalPlayer)
        {
            mover.enabled = true;
            follower.enabled = true;
        }
	}
}