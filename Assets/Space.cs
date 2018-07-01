using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Space : MonoBehaviour {

	public Text buttonText;
	private GameController gameController;
	public Button button;
		
	public void SetSpace()
	{
		buttonText.text = gameController.GetSide();
		button.interactable = false;
		gameController.EndTurn();
	}

	public void SetControllerReference(GameController control)
	{
		gameController = control;
	}
}
