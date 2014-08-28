private var leafOffset;
private var frameOffset;
private var skullOffset;

private var RibbonOffsetX;
private var FrameOffsetX;
private var SkullOffsetX;
private var RibbonOffsetY;
private var FrameOffsetY;
private var SkullOffsetY;

private var WSwaxOffsetX;
private var WSwaxOffsetY;
private var WSribbonOffsetX;
private var WSribbonOffsetY;
	
private var spikeCount;

// This script will only work with the Necromancer skin
var mySkin : GUISkin;

public var num1 : int;
public var num2 : int;

//if you're using the spikes you'll need to find sizes that work well with them these are a few...
//private var windowRect3 = Rect (Screen.width-800, Screen.height-500, 350, 400);
//private var menuRect = Rect (Screen.width-800, Screen.height-500, 350, 400);
private var menuRect = Rect (Screen.width/2-175, Screen.height/2-200, 350, 400);

private var scrollPosition : Vector2;
private var HroizSliderValue = 0.5;
private var VertSliderValue = 0.5;

public var paused : boolean;
public var menu : boolean;
public var quit : boolean;
public var mouse : boolean;

public var xSin: float;
public var ySin: float;
public var inverse : float;

//function that adds spikes to the top of the GUI window
function AddSpikes(winX){
	spikeCount = Mathf.Floor(winX - 152)/22;
	GUILayout.BeginHorizontal();
	GUILayout.Label ("", "SpikeLeft");//-------------------------------- custom
	for (i = 0; i < spikeCount; i++)
        {
			GUILayout.Label ("", "SpikeMid");//-------------------------------- custom
        }
	GUILayout.Label ("", "SpikeRight");//-------------------------------- custom
	GUILayout.EndHorizontal();
}

//Adds a skull and gold leaf to the top of the GUI window
function FancyTop(topX){
	leafOffset = (topX/2)-64;
	frameOffset = (topX/2)-27;
	skullOffset = (topX/2)-20;
	GUI.Label(new Rect(leafOffset, 18, 0, 0), "", "GoldLeaf");//-------------------------------- custom	
	GUI.Label(new Rect(frameOffset, 3, 0, 0), "", "IconFrame");//-------------------------------- custom	
	GUI.Label(new Rect(skullOffset, 12, 0, 0), "", "Skull");//-------------------------------- custom	
}

//Adds a wax seal to the bottom of the GUI window
function WaxSeal(x,y){
	WSwaxOffsetX = x - 120;
	WSwaxOffsetY = y - 115;
	WSribbonOffsetX = x - 114;
	WSribbonOffsetY = y - 83;
	GUI.Label(new Rect(WSribbonOffsetX, WSribbonOffsetY, 0, 0), "", "RibbonBlue");//-------------------------------- custom	
	GUI.Label(new Rect(WSwaxOffsetX, WSwaxOffsetY, 0, 0), "", "WaxSeal");//-------------------------------- custom	
}

//The GUI window that handles the options in the pause menu
function OptionMenu(){
	AddSpikes(menuRect.width);
	FancyTop(menuRect.width);
	GUILayout.Space(8);
		GUILayout.BeginVertical();
		GUILayout.Label("Options");
		GUILayout.Label("Mouse Sensitivity", "Divider");
		GUILayout.Space(8);
		//Slider that adjusts the mouse sensitivity with a range of 0-20
		xSin = GUILayout.HorizontalSlider(xSin, 5.0, 25.0);
		GUILayout.Label ("", "Divider");
		//GUI Button, if selected returns the mouse sensitivity and inverse to it's default setting
		// of 20 and no-inverse
		if(GUILayout.Button("Default")){
			xSin = 15;
		}
		//GUI Button, if selected changes the mouse sensitivity and inverses the controls if needed
		if(GUILayout.Button("OK")){
			MouseLook.sensitivityX = xSin;
			MouseLook.sensitivityY = xSin;
			mouse = false;
		}	
        GUILayout.EndVertical();
        WaxSeal(menuRect.width , menuRect.height);
}

//GUI Window that appears if the player wishes to return to the Main Menu
//Will be prompted Are You Sure? 
function ReturnToMenu(){
	AddSpikes(menuRect.width);
	FancyTop(menuRect.width);
	GUILayout.Space(8);
		GUILayout.BeginVertical();
		GUILayout.Label("Are You Sure?");
		GUILayout.Label ("", "Divider");
		if(GUILayout.Button("Yes")){
			Application.LoadLevel(0);
		}		
		GUILayout.Label ("", "Divider");
		if(GUILayout.Button("No")){
			menu = false;
		}
        GUILayout.EndVertical();
        WaxSeal(menuRect.width , menuRect.height);
}

//GUI Window that appears if the player wishes to exit the application
//Will be prompted Are You Sure? 
function QuitGame(){
	AddSpikes(menuRect.width);
	FancyTop(menuRect.width);
	GUILayout.Space(8);
		GUILayout.BeginVertical();
		GUILayout.Label("Are You Sure?");
		GUILayout.Label ("", "Divider");
		if(GUILayout.Button("Yes")){
			Application.Quit();
		}		
		GUILayout.Label ("", "Divider");
		if(GUILayout.Button("No")){
			quit = false;
		}
        GUILayout.EndVertical();
        WaxSeal(menuRect.width , menuRect.height);
}

//bringing it all together
function PauseMenu () {
		// use the spike function to add the spikes
		AddSpikes(menuRect.width);
		//add a fancy top using the fancy top function
		FancyTop(menuRect.width);
		GUILayout.Space(8);
		GUILayout.BeginVertical();
		GUILayout.Label("Paused");
		GUILayout.Label ("", "Divider");
		//GUI Buttons that will either unpause the game, go to the options menu, main menu, or exit game
		if(GUILayout.Button("Resume Game")){
			UnpauseGame();
		}		
		GUILayout.Label ("", "Divider");
		if(GUILayout.Button("Options")){	
			mouse = true;		
		}
		GUILayout.Label ("", "Divider");
		if(GUILayout.Button("Main Menu")){
			menu = true;
		}
		GUILayout.Label ("", "Divider");
		if(GUILayout.Button("Exit Game")){
			quit = true;
		}
		GUILayout.Space(24);
        GUILayout.EndVertical();
		// add a wax seal at the bottom of the window
		WaxSeal(menuRect.width , menuRect.height);
}

//The functions that will create the GUI that will be seen on screen.
function OnGUI (){
	GUI.skin = mySkin;
	if(paused == true && menu == false && quit == false && mouse ==false){
		menuRect = GUI.Window (3, menuRect, PauseMenu, "");
		GUI.BeginGroup (Rect (0,0,100,100));
		GUI.EndGroup ();
	}
	if(paused == true && menu == true && quit == false && mouse ==false){
		menuRect = GUI.Window (3, menuRect, ReturnToMenu, "");
		GUI.BeginGroup (Rect (0,0,100,100));
		GUI.EndGroup ();
	}
	if(paused == true && menu == false && quit == true && mouse ==false){
		menuRect = GUI.Window (3, menuRect, QuitGame, "");
		GUI.BeginGroup (Rect (0,0,100,100));
		GUI.EndGroup ();
	}
	if(paused == true && menu == false && quit == false && mouse == true){
		menuRect = GUI.Window (3, menuRect, OptionMenu, "");
		GUI.BeginGroup (Rect (0,0,100,100));
		GUI.EndGroup ();
	}
}

//Initializates values
function Start(){
	paused = false;
	menu = false;
	quit = false;
	mouse = false;
	xSin = MouseLook.sensitivityX;
	ySin = MouseLook.sensitivityY;
	Time.timeScale = 1;
}

//Pauses the game
function PauseGame(){
	paused = true;
	Time.timeScale = 0;
	AudioListener.pause = true;
}

//Unpauses the game
function UnpauseGame(){
	paused = false;
	Time.timeScale = 1;
	AudioListener.pause = false;
}

function Update(){
	//Checks if the game is paused and pauses or unpauses based on if the player hits the escape key
	if(paused == true){
		if(Input.GetKeyDown("escape")){
			UnpauseGame();
		}
	}
	if(paused == false){
		if(Input.GetKeyDown("escape")){
			PauseGame();
		}
	}
	//If the game is paused, the player cannot move the camera or the first person controller
	if(Time.timeScale == 0){
			GameObject.Find("First Person Controller").GetComponent("MouseLook").enabled = false;            
      		GameObject.Find("Main Camera").GetComponent("MouseLook").enabled = false;      
      		Screen.showCursor = true;
		}
		else{
			GameObject.Find("First Person Controller").GetComponent("MouseLook").enabled = true;            
	      	GameObject.Find("Main Camera").GetComponent("MouseLook").enabled = true; 
	      	Screen.showCursor = false;
	}
}