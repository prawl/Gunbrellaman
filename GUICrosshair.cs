using UnityEngine;
using System.Collections;

public class GUICrosshair : MonoBehaviour {
	
	public Texture2D crosshair;
	public Rect position;
	
	void OnGUI(){
		GUI.DrawTexture(position,crosshair);
	}
	
	// Update is called once per frame
	void Update () {		
		position = new Rect((Screen.width-crosshair.width)/2, (Screen.height-crosshair.height)/2, crosshair.width, crosshair.height);
	}
}
