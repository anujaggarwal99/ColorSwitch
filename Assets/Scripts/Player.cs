using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float jumpForce = 10f;

	public Rigidbody2D rb;
	public SpriteRenderer sr;
	public string currentColor;
	public static bool isAlive = true;

	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPink;
	public GameObject GameEnded;
	
	void Start ()
	{
		isAlive=true;
		Time.timeScale=1;
        rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		SetRandomColor();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			GamePlayAudio.playSound("tap");
			rb.velocity = Vector2.up * jumpForce;
		}
	}
    
		
	void OnTriggerEnter2D (Collider2D col)
	{
		 if (col.gameObject.CompareTag("star"))
		 {
			 GamePlayAudio.playSound("starCollect");
			 col.gameObject.SetActive(false);
			 ScoreManager.score += 1;
             return;
		 }
		

		if (col.tag == "ColorChanger")
		{  
			GamePlayAudio.playSound("changerSound");
			col.gameObject.SetActive(false); 
			SetRandomColor();
			return;
		}

		if (col.tag != currentColor && col.tag !="star")
		{
			isAlive = false;
			
		    GamePlayAudio.playSound("gameOver");
			
			Time.timeScale=0;
		
			
			Debug.Log("GAME OVER!");
			GameEnded.SetActive(true);
			
		}
	}

	

	void SetRandomColor ()
	{
		int index = Random.Range(0, 4);

		switch (index)
		{
			case 0:
				currentColor = "Cyan";
				sr.color = colorCyan;
				break;
			case 1:
				currentColor = "Yellow";
				sr.color = colorYellow;
				break;
			case 2:
				currentColor = "Magenta";
				sr.color = colorMagenta;
				break;
			case 3:
				currentColor = "Pink";
				sr.color = colorPink;
				break;
		}
	}


}
