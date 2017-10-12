﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
using UnityEngine.UI;


public class PauseMenuImproved : MonoBehaviour
{
	//ublic bool boolIsOn;

	private float m_TimeScaleRef = 1f;
	private float m_VolumeRef = 1f;
	public bool m_Paused = false;


	void Awake()
	{
		
	}


	private void MenuOn ()
	{
		m_TimeScaleRef = Time.timeScale;
		Time.timeScale = 0f;

		m_VolumeRef = AudioListener.volume;
		AudioListener.volume = 0f;

		m_Paused = true;
	}


	public void MenuOff ()
	{
		Time.timeScale = m_TimeScaleRef;
		AudioListener.volume = m_VolumeRef;
		m_Paused = false;
	}


	public void OnMenuStatusChange ()
	{
		if (!m_Paused)
		{
			MenuOn();
		}
		else if (m_Paused)
		{
			MenuOff();
		}
	}

}
