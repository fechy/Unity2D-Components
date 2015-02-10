﻿using UnityEngine;
using System.Collections;


public class GameData : MonoBehaviour
{
	// player stats.
    private static int _currentScore;     	    
    private static int _lastSavedScore;
    private static int _lives = 3;

    // level stats.
    private static int _currentLevel;  

	public static int GetScore()
	{
		return _currentScore;
	}

	public static void IncreaseScore(int addScore)
	{
		_currentScore += addScore;
	}

	public static int GetLives()
	{
		return _lives;
	}

	public static void IncreaseLives(int addLives)
	{
		_lives += addLives;
	}
}
