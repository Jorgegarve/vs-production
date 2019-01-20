using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState 
{ 
	PROTOTYPE
}

public class GameManager : MonoBehaviour
{
    public CameraController cameraController;

    public delegate void OnStateChangeHandler ();
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }

    public bool isGamePaused = false;

    protected GameManager () {}
	private static GameManager instance = null;

    public static GameManager Instance {
        get {
            if (GameManager.instance == null){
                DontDestroyOnLoad (GameManager.instance);
                GameManager.instance = new GameManager ();
            }
            return GameManager.instance;
        }
    }

	private void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<CameraController> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameState (GameState state)
	{
        this.gameState = state;
        OnStateChange ();
    }

    public void Resume () 
	{
		SetTimeScale (1f);
	}

	public void Pause () 
	{
		isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Resume ();
        } else
        {
            SetTimeScale (0f);
        }
		
	}

	private void SetTimeScale (float timeScale)
	{
		Time.timeScale = timeScale;
	}

	public void OnApplicationQuit ()
	{
        GameManager.instance = null;
    }
}
