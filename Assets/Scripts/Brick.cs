using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    private static int brickCounter = 0;
    private int timesHit;

    private LevelManager levelManager;
    private AudioSource audioBrick;

    public Sprite[] HitSprite;
    // Use this for initialization
    void Start() {
        audioBrick = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        timesHit = 0;
        if (this.tag == "Breakable") {
            brickCounter++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack,transform.position);
        int maxHits = HitSprite.Length + 1;
        timesHit += 1;
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
            brickCounter--;
        } else
        {
            LoadSprites();
        }

        if (brickCounter == 0)
        {
            levelManager.LoadNextLevel();
        }
    }

    void LoadSprites()
    {
        int SpriteCounter = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = HitSprite[SpriteCounter];
    }

}
