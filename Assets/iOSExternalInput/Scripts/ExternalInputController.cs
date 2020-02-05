using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ExternalInputDidReceiveKey(KeyCode receivedKey);
public class ExternalInputController : MonoBehaviour {

	public static ExternalInputController instance = null;

	public event ExternalInputDidReceiveKey OnExternalInputDidReceiveKey;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		} else if(instance != this)
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		ExternalInputInterface.SetupExternalInput();
	}

	public void DidReceiveKeystroke(string receivedKeystroke)
	{
		KeyCode receivedKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), receivedKeystroke);

		if(OnExternalInputDidReceiveKey != null)
			OnExternalInputDidReceiveKey(receivedKeyCode);
	}
}
