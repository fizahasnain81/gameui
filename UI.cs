/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // [SerializeField] private Slider musicVolumeSlider; // Slider for music volume adjustment
    // private AudioSource backgroundMusic;
    // public Slider musicVolumeSlider;  // Reference to the music volume slider
    // public Slider snakeSpeedSlider;   // Reference to the snake speed slider
    // public AudioSource backgroundMusic; // Reference to the AudioSource for music
    public GameObject victorypanel;
    public GameObject mappanel;
    public GameObject pausepanel;
    public GameObject pausebtn;
    public GameObject gameoverpanel;
    public player3 GameMechanicsReference1;
    //public Text HighScore1;
    // public AudioSource audioSource11;
    // Start is called before the first frame update
    public Text scoreText; // Reference to score UI
    //public Text highScoreText; // Reference to high score UI
    void Start()
    {
        victorypanel.SetActive(false);
        gameoverpanel.SetActive(false);
        mappanel.SetActive(true);
        pausebtn.SetActive(true);

        pausepanel.SetActive(false);
        //musicVolumeSlider.value = backgroundMusic.volume; // Set to current music volume
      //  snakeSpeedSlider.value = GameMechanicsReference1.speed;
       // backgroundMusic = FindObjectOfType<AudioSource>();

        // Check if the AudioSource exists to avoid null reference errors
        /*if (backgroundMusic != null)
        {
            // Set the slider's value to the current volume
            musicVolumeSlider.value = backgroundMusic.volume;

            // Add a listener to the slider to update the volume in real-time
            musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        }
        else
        {
            Debug.LogWarning("No AudioSource found in the scene. Make sure the AudioSource is set to persist.");
        }*/

    }
   /* public void OnMusicVolumeChanged(float value)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = value;

            // Save the volume to PlayerPrefs
            PlayerPrefs.SetFloat("MusicVolume", value);
            PlayerPrefs.Save();
        }
    }*/

   /* void OnDestroy()
    {
        // Remove the listener to avoid potential memory leaks
        musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
    }*/
    void Update()
    {

    }
    public void ShowLosePanel1()
    {



        gameoverpanel.SetActive(true);
        GameMechanicsReference1.isGameOver = true;

        /*if (GameMechanicsReference1 != null)
        {
            GameMechanicsReference1.isGameOver = true; // Set the flag in the player's script

            // Stop Rigidbody movement (if using Rigidbody)
            Rigidbody rb = GameMechanicsReference1.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            // Disable the player's movement script
            GameMechanicsReference1.enabled = false;

        }*/
    }
    public void VictoryPanel1()
    {


        victorypanel.SetActive(true);

    }
    public void mapPanel1()
    {


        mappanel.SetActive(false);

    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
        //highScoreText.text = "High Score: " + highScore.ToString();
    }
    public void Retry1()
    {
        // SoundManager.PlaySound(SoundManager.Sound.ButtonOver);
        SceneManager.LoadScene("Volcanic");
    }
    public void Retry2()
    {
        // SoundManager.PlaySound(SoundManager.Sound.ButtonOver);
        SceneManager.LoadScene("Volcanic");
    }

    // Update is called once per frame
    public void PausePanelShowHide1()
    {
        if (GameMechanicsReference1.isPaused == true)
        {
            pausepanel.SetActive(true);
        }
        else if (GameMechanicsReference1.isPaused == false)
        {
            pausepanel.SetActive(false);
        }

    }

    public void Mainmenu1()
    {
        SceneManager.LoadScene("mainmenuScene");
    }

    /*public void OnMusicVolumeChanged()
    {
        //backgroundMusic.volume = musicVolumeSlider.value; // Adjust music volume
        backgroundMusic.volume = musicVolumeSlider.value; // Adjust music volume
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value); // Save value
        PlayerPrefs.Save(); // Ensure data is written to disk
    }*/
   /* public void OnSnakeSpeedChanged()
    {
        //  GameMechanicsReference1.speed = snakeSpeedSlider.value; // Adjust snake speed
        //  Time.fixedDeltaTime = GameMechanicsReference1.speed; // Update game speed
        GameMechanicsReference1.speed = snakeSpeedSlider.value; // Adjust snake speed
        Time.fixedDeltaTime = GameMechanicsReference1.speed; // Update game speed
        PlayerPrefs.SetFloat("SnakeSpeed", snakeSpeedSlider.value); // Save value
        PlayerPrefs.Save(); // Ensure data is written to disk
    }*/
    /*public void displayHighScore()
    {
        HighScore1.text = GameMechanicsReference1.HighScore1.ToString();
    }*/

}
