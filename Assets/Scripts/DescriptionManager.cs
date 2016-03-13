﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DescriptionManager : MonoBehaviour {

	private DescriptionSoundEffect descriptionSoundEffect;

	void Start()
	{
		descriptionSoundEffect = GameObject.Find("DescriptionSoundEffect").
			GetComponent<DescriptionSoundEffect>();
	}

	void OnStage01ButtonClicked()
	{
		descriptionSoundEffect.GameStart();
		Invoke ("GoToStage01", 1.0f);
	}
	void OnStage02ButtonClicked()
	{
		descriptionSoundEffect.GameStart();
		Invoke ("GoToStage02", 1.0f);
	}
	
	void GoToStage01()
	{
		TitleManager.Stage01 = true;
		SceneManager.LoadScene ("Stage01");
	}
	void GoToStage02()
	{
		TitleManager.Stage02 = true;
		SceneManager.LoadScene ("Stage02");
	}
}