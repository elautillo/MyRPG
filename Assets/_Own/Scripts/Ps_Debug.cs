using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ps_Debug : MonoBehaviour
{
	const string Cf_INTERACTING_MESSAGE = "Interacting...";
	const string Cf_NON_INTERACTABLE_MESSAGE = "Non interactable.";
	const string Cf_NO_DETECTION_MESSAGE = "Nothing detected.";


	public static string GetInteractingMessage()
	{
		return Cf_INTERACTING_MESSAGE;
	}


	public static string GetNonInteractableMessage()
	{
		return Cf_NON_INTERACTABLE_MESSAGE;
	}


	public static string GetNoDetectionMessage()
	{
		return Cf_NO_DETECTION_MESSAGE;
	}
}
