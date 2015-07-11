using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour
{
	[SerializeField] CharacterMovement mover;

	void Start ()
    {
        if(isLocalPlayer)
        {
            mover.enabled = true;
        }
	}
}