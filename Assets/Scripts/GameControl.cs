using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	public  bool PlayerOneDead;
	public  bool PlayerTwoDead;
	public  int ScorePlayerOne;	
	public  int ScorePlayerTwo;	
	public float EnemySpawnTime = 10f;
    public int MaxEnemyWaves = 10;
	public Transform[] EnemySpawn;
	public Transform PlayerOneSpawn;
	public Transform PlayerTwoSpawn;
	public GameObject PlayerOne;
	public GameObject PlayerTwo;
	public GameObject EnemyPrefab;
	public Headquarter Headquarter;
	public Text PlayerOneScoresText;
	public Text PlayerTwoScoresText;
	public Text TankText;
	private int _maxEnemyTanks;
	public int LeftEnemyTanks;

	public GameObject GameOverMenu;
	public GameObject OptionBtn;
	public GameObject VictoryWindow;
	public bool IsAliveHead;

	private int _numberOfPlayers;

	void Start()
	{
        //Выбор с главного меню 1-2 игрока
        _numberOfPlayers = FindObjectOfType<NumberOfPlayers>().NumberPlayers;
		
		_maxEnemyTanks = MaxEnemyWaves * 3;
        LeftEnemyTanks = _maxEnemyTanks;
		PlayerOneDead = false;
		ScorePlayerOne = 0;
		ScorePlayerTwo = 0;
		
		StartCoroutine(WaitEnemySpawn(EnemySpawnTime));
		Instantiate(PlayerOne, PlayerOneSpawn.position, Quaternion.identity);
		

		if (_numberOfPlayers == 1)
        {
            PlayerTwo.SetActive(false);
            PlayerTwoScoresText.enabled = false;
            PlayerTwoSpawn.gameObject.SetActive(false);
            PlayerTwoDead = true;
		}
        if (_numberOfPlayers == 2)
        {
			PlayerTwo.SetActive(true);
			PlayerTwoScoresText.enabled = true;
			PlayerTwoSpawn.gameObject.SetActive(true);
			PlayerTwoDead = false;
			Instantiate(PlayerTwo, PlayerTwoSpawn.position, Quaternion.identity);
		}
		UpdateTextPlayers();
	}

    private void Update()
    {		

		if (LeftEnemyTanks <= 0)
        {			
				VictoryWindow.SetActive(true);
				OptionBtn.SetActive(false);
				Time.timeScale = 0f;
		}
		if (IsAliveHead == false)
		{			
				GameOverMenu.SetActive(true);
				OptionBtn.SetActive(false);
				Time.timeScale = 0f;
		}
		
		if (_numberOfPlayers == 1)
        {
			if (PlayerOneDead)
			{	
					GameOverMenu.SetActive(true);
					OptionBtn.SetActive(false);
					Time.timeScale = 0f;
			}			
		}
		if (_numberOfPlayers == 2)
		{
			
			if (PlayerOneDead && PlayerTwoDead)
			{				
					GameOverMenu.SetActive(true);
					OptionBtn.SetActive(false);
					Time.timeScale = 0f;			
			}
			
		}
        
    }

    IEnumerator WaitEnemySpawn(float periodSpawns)
	{
		foreach (Transform obj in EnemySpawn)
		{            
			Instantiate(EnemyPrefab, obj.position, obj.rotation);
		}
        MaxEnemyWaves--;
		yield return new WaitForSeconds(periodSpawns);
		if (MaxEnemyWaves > 0) StartCoroutine (WaitEnemySpawn(EnemySpawnTime));
	}

	
	public void UpdateTextPlayers()
	{
        PlayerOneScoresText.text = "P1 Scores: " + ScorePlayerOne.ToString();
		PlayerTwoScoresText.text = "P2 Scores: " + ScorePlayerTwo.ToString();
        TankText.text = "Tanks left: " + LeftEnemyTanks.ToString();
    }
	
}
