using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject gameOverPanel;
	public Text gameOverText;
	public Text[] spaceList;
	public GameObject resetButton;
	private string side;
	private int moves;

	void Start () {
		
		SetGameControllerReferenceForButtons();
		side = "X";
		gameOverPanel.SetActive(false);
		moves = 0;
		resetButton.SetActive(false);
	}
	
	void SetGameControllerReferenceForButtons()
	{
		for (int i = 0; i < spaceList.Length; i++){
			spaceList[i].GetComponentInParent<Space>().SetControllerReference(this);
		}
	}

	void ChangeSide()
	{
	if (side == "X")
		side = "O";
	else
		side = "X";
	}

	public string GetSide()
	{
		return side;
	}

	public void EndTurn()
	{
        moves++;

        if (spaceList[0].text == side && spaceList[1].text == side && spaceList[2].text == side)
        {
            GameOver();
        }
        else if (spaceList[3].text == side && spaceList[4].text == side && spaceList[5].text == side)
        {
            GameOver();
        }
        else if (spaceList[6].text == side && spaceList[7].text == side && spaceList[8].text == side)
        {
            GameOver();
        }
        else if (spaceList[0].text == side && spaceList[3].text == side && spaceList[6].text == side)
        {
            GameOver();
        }
        else if (spaceList[1].text == side && spaceList[4].text == side && spaceList[7].text == side)
        {
            GameOver();
        }
        else if (spaceList[2].text == side && spaceList[5].text == side && spaceList[8].text == side)
        {
            GameOver();
        }
        else if (spaceList[0].text == side && spaceList[4].text == side && spaceList[8].text == side)
        {
            GameOver();
        }
        else if (spaceList[2].text == side && spaceList[4].text == side && spaceList[6].text == side)
        {
            GameOver();
        }
        if (moves > 8)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "Tie!!!";
            resetButton.SetActive(true);
        }
        ChangeSide();
	}

	public void Restart()
	{
		moves = 0;
        side = "X";
        gameOverPanel.SetActive(false);
        SetInteractable(true);
        resetButton.SetActive(false);

        for (int i = 0; i < spaceList.Length; i++){
            spaceList[i].text = "";
        }
	}

	void GameOver()
	{
	    gameOverPanel.SetActive(true);
	    gameOverText.text = side + " wins!";
	    resetButton.SetActive(true);
	    for (int i = 0; i < spaceList.Length; i++){
	        SetInteractable(false);
	    }
	}

	void SetInteractable(bool setting)
	{
        for (int i = 0; i < spaceList.Length; i++)
            spaceList[i].GetComponentInParent<Button>().interactable = setting;
	}
	
}
