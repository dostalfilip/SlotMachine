using UnityEngine;
using System.Collections;

public class PointScript : MonoBehaviour {

	public enum PointState
		{
		Off,On,Blinking
	}
    public Sprite LightSprite;

    private const float blinkInterval = 0.2f;
	private SpriteRenderer spriteRenderer;
	private Sprite origSprite;
	private float blinkTimer;
	private PointState state;

	public PointState State
    { 
		get {return state;}
		set { if (state==value) return;
			state=value;
			if (state==PointState.Blinking) blinkTimer=0f;
		}
	}

	void Start () {
		spriteRenderer=gameObject.GetComponent<SpriteRenderer>();
		origSprite=spriteRenderer.sprite;
		blinkTimer=0f;
		state=PointState.Blinking;       
    }
	
	void Update () {        
		switch (State)
        {
		case PointState.Off:
			if (spriteRenderer.sprite!=origSprite) spriteRenderer.sprite=origSprite;
			break;
		case PointState.On:
			if (spriteRenderer.sprite!=LightSprite) spriteRenderer.sprite=LightSprite;
			break;
		case PointState.Blinking:
			blinkTimer+=Time.deltaTime;
			if (blinkTimer>blinkInterval){
				blinkTimer-=blinkInterval;
				spriteRenderer.sprite = (spriteRenderer.sprite==origSprite ? LightSprite : origSprite);
			}
			break;
		}
	}
}
