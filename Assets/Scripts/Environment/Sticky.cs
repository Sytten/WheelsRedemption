using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Sticky : MonoBehaviour {

    public Sprite normalSprite;
    public Sprite notStickySprite;

    public bool isSticky = true;

    private WheelBehavior wheelBehavior;
    private SpriteRenderer spriteRenderer;

	void Start () {
        wheelBehavior = GetComponent<WheelBehavior>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
	    if(isSticky) {
            spriteRenderer.sprite = normalSprite;
        } else {
            spriteRenderer.sprite = notStickySprite;
        }
        wheelBehavior.isSticky = isSticky;
    }
}
