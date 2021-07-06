using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { private set; get; }

    [SerializeField] private Player playerPrefab;
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private Arena[] levels;
    public GameObject[] powerUpPrefabs;

    private int currentLevel;
    private int currentBlocksAmount;

    public Ball ball { private set; get; }
    public Player player { private set; get; }
    public bool isInputEnabled { private set; get; }
    public int score { private set; get; }
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    private void Start()
    {
        currentLevel = 0;
        currentBlocksAmount = levels[currentLevel].blocksAmount;
        score = 0;
        StartCoroutine(StartLevel());
    }
    private void Update()
    {
        if (currentBlocksAmount <= 0)
        {
            EndLevel();
            currentLevel++;
            if (currentLevel < levels.Length)
            {
                currentBlocksAmount = levels[currentLevel].blocksAmount;
                StartCoroutine(StartLevel());
            }
            else
            {
                StartCoroutine(AnnouncementManager.instance.ShowAnnouncement("Victory!"));
            }
        }
    }
    public void GameLoose()
    {
        Time.timeScale = 0;
    }
    private IEnumerator StartLevel()
    {
        isInputEnabled = false;
        player = Instantiate(playerPrefab, levels[currentLevel].playerSpawnPoint);
        player.transform.SetParent(null);
        ball = Instantiate(ballPrefab, levels[currentLevel].ballSpawnPoint);
        ball.transform.SetParent(null);
        Camera.main.transform.position = levels[currentLevel].cameraPosition.position;
        yield return StartCoroutine(AnnouncementManager.instance.ShowAnnouncement($"Level {currentLevel + 1}"));
        isInputEnabled = true;
    }
    private void EndLevel()
    {
        Destroy(player.gameObject);
        Destroy(ball.gameObject);
    }
    public void ReduceBlocksAmount()
    {
        currentBlocksAmount--;
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
    }
}
