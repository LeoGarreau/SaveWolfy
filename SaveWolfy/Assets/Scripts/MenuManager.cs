﻿using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	
	public float aspectWidth = 16.0f;
	public float aspectHeight = 9.0f;
	public RectTransform mainMenuPanel;
	public RectTransform skinPanel;

	public RectTransform changeSkinButton0;
	public RectTransform changeSkinButton1;
	public RectTransform changeSkinButton2;
	public RectTransform changeSkinButton3;
	int skinScrollingState;

	public RectTransform changeCursorButton0;
	public RectTransform changeCursorButton1;
	public RectTransform changeCursorButton2;
	public RectTransform changeCursorButton3;
	public RectTransform changeCursorButton4;
	int cursorScrollingState;

	void adaptScreenRatio () {

		// set the desired aspect ratio (the values in this example are
		// hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		float targetAspect = aspectWidth / aspectHeight;

		// determine the game window's current aspect ratio
		float windowAspect = (float)Screen.width / Screen.height;

		// current viewport height should be scaled by this amount
		float scaleHeight = windowAspect / targetAspect;


		// if scaled height is less than current height, add letterbox
		if (scaleHeight < 1.0f)
		{
			Rect rect = Camera.main.rect;

			rect.width = 1.0f;
			rect.height = scaleHeight;
			rect.x = 0;
			rect.y = (1.0f - scaleHeight) / 2.0f;

			Camera.main.rect = rect;
		}
		else // add pillarbox
		{
			float scaleWidth = 1.0f / scaleHeight;

			Rect rect = Camera.main.rect;

			rect.width = scaleWidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scaleWidth) / 2.0f;
			rect.y = 0;

			Camera.main.rect = rect;
		}
	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		SoundManager.instance.PauseMusic(false);
		adaptScreenRatio();
		GameData.ResetValues();
		CheckData ();
	}

	public void OpenSkinMenu(){
		mainMenuPanel.GetComponent<CanvasGroup>().alpha = 0;
		mainMenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

		skinPanel.GetComponent<CanvasGroup>().alpha = 1;
		skinPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void OpenMainMenu(){
		skinPanel.GetComponent<CanvasGroup>().alpha = 0;
		skinPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

		mainMenuPanel.GetComponent<CanvasGroup>().alpha = 1;
		mainMenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void SkinScrollRigth(){
		if (skinScrollingState < 3) {
			skinScrollingState = skinScrollingState + 1;
		}
		else {
			skinScrollingState = 0;
		}

		switch (skinScrollingState) {
		case 0:
			changeSkinButton3.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton3.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton0.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton0.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 1:
			changeSkinButton0.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton0.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton1.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton1.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 2:
			changeSkinButton1.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton1.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton2.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton2.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 3:
			changeSkinButton2.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton2.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton3.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton3.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;
		default:
			break;
		}
	}

	public void SkinScrollLeft(){
		if (skinScrollingState > 0) {
			skinScrollingState = skinScrollingState - 1;
		} else {
			skinScrollingState = 3;
		}

		switch (skinScrollingState) {
		case 0:
			changeSkinButton1.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton1.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton0.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton0.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 1:
			changeSkinButton2.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton2.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton1.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton1.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 2:
			changeSkinButton3.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton3.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton2.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton2.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 3:
			changeSkinButton0.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton0.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton3.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton3.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;
		default:
			break;
		}
	}

	public void CursorScrollRigth(){
		if (cursorScrollingState < 4) {
			cursorScrollingState = cursorScrollingState + 1;
		}
		else {
			cursorScrollingState = 0;
		}

		switch (cursorScrollingState) {
		case 0:
			changeCursorButton4.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton4.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton0.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton0.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 1:
			changeCursorButton0.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton0.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton1.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton1.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 2:
			changeCursorButton1.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton1.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton2.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton2.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 3:
			changeCursorButton2.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton2.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton3.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton3.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;
		case 4:
			changeCursorButton3.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton3.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton4.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton4.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;
		default:
			break;
		}
	}

	public void CursorScrollLeft(){
		if (cursorScrollingState > 0) {
			cursorScrollingState = cursorScrollingState - 1;
		} else {
			cursorScrollingState = 4;
		}

		switch (cursorScrollingState) {
		case 0:
			changeCursorButton1.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton1.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton0.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton0.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 1:
			changeCursorButton2.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton2.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton1.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton1.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 2:
			changeCursorButton3.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton3.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton2.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton2.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 3:
			changeCursorButton4.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton4.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton3.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton3.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;
		case 4:
			changeCursorButton0.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton0.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton4.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton4.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;
		default:
			break;
		}
	}

	public void UnlockSkin(int id){
		switch (id) {
		case 0:
			changeSkinButton1.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetInt ("groundSkin1", 1);
			break;
		case 1:
			changeSkinButton2.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetInt ("groundSkin2", 1);
			break;
		case 2:
			changeSkinButton3.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetInt ("groundSkin3", 1);
			break;
		case 3:
			changeCursorButton1.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetInt ("cursorSkin1", 1);
			break;
		case 4:
			changeCursorButton2.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetInt ("cursorSkin2", 1);
			break;
		case 5:
			changeCursorButton3.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetInt ("cursorSkin3", 1);
			break;
		case 6:
			changeCursorButton4.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetInt ("cursorSkin4", 1);
			break;
		default:
			break;
		}
	}

	void CheckData(){
		int groundSkin1 = PlayerPrefs.GetInt ("groundSkin1");
		int groundSkin2 = PlayerPrefs.GetInt ("groundSkin2");
		int groundSkin3 = PlayerPrefs.GetInt ("groundSkin3");
		int cursorSkin1 = PlayerPrefs.GetInt ("cursorSkin1");
		int cursorSkin2 = PlayerPrefs.GetInt ("cursorSkin2");
		int cursorSkin3 = PlayerPrefs.GetInt ("cursorSkin3");
		int cursorSkin4 = PlayerPrefs.GetInt ("cursorSkin4");

		if (groundSkin1 == 1) {
			changeSkinButton1.GetComponent<Button> ().interactable = true;
		}

		if (groundSkin2 == 1) {
			changeSkinButton2.GetComponent<Button> ().interactable = true;
		}

		if (groundSkin3 == 1) {
			changeSkinButton3.GetComponent<Button> ().interactable = true;
		}

		if (cursorSkin1 == 1) {
			changeCursorButton1.GetComponent<Button> ().interactable = true;
		}

		if (cursorSkin2 == 1) {
			changeCursorButton2.GetComponent<Button> ().interactable = true;
		}

		if (cursorSkin3 == 1) {
			changeCursorButton3.GetComponent<Button> ().interactable = true;
		}

		if (cursorSkin4 == 1) {
			changeCursorButton4.GetComponent<Button> ().interactable = true;
		}
	}
}