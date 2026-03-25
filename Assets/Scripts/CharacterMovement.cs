using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float normalMoveSpeed = 5f; // Speed of the normal movement
    public float shiftMoveSpeed = 2f;  // Speed of the shift movement
    private Rigidbody2D rb;
    public float currentMoveSpeed;
    public int treasureSold =0;
    public bool didWin=false;
    private SpriteRenderer spriteRenderer;
    // Ses efektleri
    public AudioSource collectSound;
    public AudioSource xCollectSound;
    public AudioSource sellSound;
    public AudioSource xSellSound;
    public AudioSource winSound;
    public AudioSource loseSound;
    public AudioSource rewardSound;

    // TREASURE EQUIPPED İ AŞŞAĞIDA "BURASI" DİYE YAZDIĞIM YERDE TEXTE GÖNDER
    void Start()
    {
        treasureSold = GameManager.Instance.tempTreasureSold;
        didWin = GameManager.Instance.tempDidWin;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Awake()
    {
        GameManager.Instance.PlayerFinder(GetComponent<PlayerController>());
        // Ses efektlerinin ayarlanması
        AudioSource[] audioSources = GetComponents<AudioSource>();
        collectSound = audioSources[0];
        xCollectSound = audioSources[1];
        sellSound = audioSources[2];
        xSellSound = audioSources[3];
        winSound = audioSources[4];
        loseSound = audioSources[5];
        rewardSound = audioSources[6];
        
}

    void Update()
    {
        HandleScenes();

        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        // FOOTSTEP'E UYGUN HIZ AYARLAMALARI
        if (Input.GetKey(KeyCode.LeftShift)&& (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            currentMoveSpeed = shiftMoveSpeed;
        }
        else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            currentMoveSpeed = normalMoveSpeed;
        }
        else
        {
            currentMoveSpeed = 0f;
        }
        
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * currentMoveSpeed;
        // Apply movement to the Rigidbody2D
        rb.velocity = movement;

        if (Input.GetMouseButtonDown(0)||Input.GetMouseButtonDown(1)|| Input.GetKeyDown(KeyCode.Space))
        {
            HandleEquip();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.treasureEquipped = 0;
            GameManager.Instance.time = 240;
            GameManager.Instance.tempTreasureSold = 0;
            GameManager.Instance.tempDidWin = false;
            GameManager.Instance.footSound = 0;
            GameManager.Instance.mainThemeAudio.Stop();
            SceneManager.LoadScene("House1");
            GameManager.Instance.mainThemeAudio.Play();
        }
    }


    // AUDIOLAR VE COLLECTING
    private void HandleEquip()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D collider in colliders)
        {   
            
            if (collider.gameObject.CompareTag("Treasure")&&GameManager.Instance.treasureEquipped<2)
            {
                collectSound.Play();
                Destroy(collider.gameObject);
                GameManager.Instance.treasureEquipped++;
                break;
            }
            else if(GameManager.Instance.treasureEquipped >2)
            {
                xCollectSound.Play();
            }
            if (collider.gameObject.CompareTag("Zone") && GameManager.Instance.treasureEquipped > 0 && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Space)))
            {
                sellSound.Play();
                GameManager.Instance.treasureEquipped--;
                treasureSold++;
            }
            else if(collider.gameObject.CompareTag("Zone") && !(GameManager.Instance.treasureEquipped > 0) && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Space)))
                xSellSound.Play();
            // REWARD
            if (collider.gameObject.CompareTag("Reward") && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Space)))
            {
                rewardSound.Play();
                Destroy(collider.gameObject);
                if (GameManager.Instance.footSound - 10000 < 0)
                    GameManager.Instance.footSound = 0;
                else
                {
                    GameManager.Instance.footSound -= 10000;
                }
            }
        }
    }

    public void UpdateFootSound()
    {
        if (currentMoveSpeed == 5f)
            GameManager.Instance.footSound += 8; 
        else if (currentMoveSpeed == 2f)
            GameManager.Instance.footSound += 4;
        else if (currentMoveSpeed == 0f&& GameManager.Instance.footSound >0)
            GameManager.Instance.footSound -=3;
    }
    
    // SAHNE GEÇİŞLERİ
    public void HandleScenes()
    {

       


        if (((GameManager.Instance.footSound / 100 > GameManager.Instance.maxFootSound) || GameManager.Instance.minutes == 6))
        {
            HandleEndScreen();
            didWin = false;
        }
        else if (treasureSold == 5)
        {
            if (SceneManager.GetActiveScene().name == "House1")
            {
                SceneManager.LoadScene("House2");
            }
            else if (SceneManager.GetActiveScene().name == "House2")
            {
                SceneManager.LoadScene("House3");
            }
            else if (SceneManager.GetActiveScene().name == "House3")
            {
                didWin = true;
                GameManager.Instance.mainThemeAudio.Stop();
                winSound.Play();
                HandleEndScreen();
            }

            treasureSold = 0;
            if (GameManager.Instance.footSound - 5000 < 0)
                GameManager.Instance.footSound = 0;
            else
            {
                GameManager.Instance.footSound -= 5000;
            }
            GameManager.Instance.treasureEquipped = 0;
        }



    }
   
    // WIN OR LOSE'A GÖRE END SCREEN
    public void HandleEndScreen()
    {
        GameManager.Instance.mainThemeAudio.Stop();
        GameManager.Instance.endAudio.Play();
        if (didWin)
        {
            SceneManager.LoadScene("WonScene");
            
        }
        else
        {
            SceneManager.LoadScene("LostScene");

        }
    }


}
