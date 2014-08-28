var skin:GUISkin;
 
private var gldepth = -0.5;
private var startTime = 0.1;
 
var mat:Material;
 
private var tris = 0;
private var verts = 0;
private var savedTimeScale:float;
private var pauseFilter;
 
private var showfps:boolean;
private var showtris:boolean;
private var showvtx:boolean;
private var showfpsgraph:boolean;
 
var lowFPSColor = Color.red;
var highFPSColor = Color.green;
 
var lowFPS = 30;
var highFPS = 50;
 
var start:GameObject;
 
var url = "unity.html";
 
var statColor:Color = Color.yellow;
 
var credits:String[]=[
	"A Butts Media Production",
	"by Team Thunder",
	"Copyright (c) 2013"] ;
	
/*var tutorials:String[]=[ " ", 
 " Introduction ",
 " Inspired by true events, Project Gunbrella is a survival game that puts the player in the perspective of the infamous gunbrella man.  While many remember the notorious day, most do not know how the real event",
 " unfolded.  Your world is turned upside down as you travel into a dimension that threatens to destroy everything you know. Everyone is counting on your success, can you survive? ",
 "  ",
 " Controls ",
 " Move character:  WASD ",
 " Move camera/reticle: Mouse",
 " Fire weapon: Mouse 1",
 " Block/defend: Mouse 2",
 " Sprint: Hold Shift",
 " Jump: Space bar",
 " Pause: Esc (Escape)",
 " ",
 "                                                                                                                                       Press any key to continue"] ; */

var crediticons:Texture[];
var tutorialcons:Texture[];
 
enum Page2 {
	None,Main,Options,Credits,Quit,Test
}
 
private var currentPage:Page2;
 
private var fpsarray:int[];
private var fps:float;
 
 
function OnPostRender() {
	if (showfpsgraph && mat != null) {
		GL.PushMatrix ();
		GL.LoadPixelMatrix();
		for (var i = 0; i < mat.passCount; ++i)
		{
			mat.SetPass(i);
			GL.Begin( GL.LINES );
			for (var x=0; x<fpsarray.length; ++x) {
				GL.Vertex3(x,fpsarray[x],gldepth);
			}
		GL.End();
		}
		GL.PopMatrix();
		ScrollFPS();
	}
}
 
function ScrollFPS() {
	for (var x=1; x<fpsarray.length; ++x) {
		fpsarray[x-1]=fpsarray[x];
	}
	if (fps < 1000) {
		fpsarray[fpsarray.length-1]=fps;
	}
}
 
static function IsDashboard() {
	return Application.platform == RuntimePlatform.OSXDashboardPlayer;
}
 
static function IsBrowser() {
	return (Application.platform == RuntimePlatform.WindowsWebPlayer ||
		Application.platform == RuntimePlatform.OSXWebPlayer);
}
 
// LateUpdate is called every frame, and only after every update function is called first
function LateUpdate () {  
	if (showfps || showfpsgraph) {
		FPSUpdate();
	}
	
	
	if (Input.GetKeyDown("escape")) {
	
		// This is where I wanted to show the tutorial instructions
		switch (currentPage) {
			case Page2.None: PauseGame(); break;
			case Page2.Main: if (!IsBeginning()) UnPauseGame(); break;
			default: currentPage = Page2.Main;
		}
	}
}
 
function OnGUI () {
	if (skin != null) {
		GUI.skin = skin;
	}
	if (IsBeginning())// On the start of the game
	{
		Time.timeScale = 0;// Pause the game
		if (Input.anyKey) {// Start the game if any key is pressed
			Time.timeScale = 1;
    	}
	}
	
	ShowStatNums();
	ShowLegal();
	if (IsGamePaused()) {
		GUI.color = statColor;
		switch (currentPage) {
			case Page2.Main: PauseMenu(); break;
			case Page2.Options: ShowToolbar(); break;
			case Page2.Credits: ShowCredits(); break;
			case Page2.Test: ShowTest(); break;
			case Page2.Quit: ShowQuit(); break;
		}
	}	
}
 
function ShowLegal() {
	if (!IsLegal()) {
		GUI.Label(Rect(Screen.width-100,Screen.height-20,90,20),
		"");
	}
}
 
function IsLegal() {
	return !IsBrowser() || 
	Application.absoluteURL.StartsWith("") ||
	Application.absoluteURL.StartsWith("");
}
 
private var toolbarInt:int=0;
private var toolbarStrings: String[]= ["Audio","Graphics","Stats","System"];
 
function ShowToolbar() {
	BeginPage(300,300);
	toolbarInt = GUILayout.Toolbar (toolbarInt, toolbarStrings);
	switch (toolbarInt) {
		case 0: VolumeControl(); break;
		case 3: ShowDevice(); break;
		case 1: Qualities(); QualityControl(); break;
		case 2: StatControl(); break;
	}
	EndPage();
}

// I want to create a GUI window that takes up the the entire screen.  It should diplay the instructions for the game
/*function ShowTutorial() {

	var guiBoxWidth = Screen.width-150;
	var guiBoxHeight = Screen.height-150;
	
	// BeginPage initalizes the size of the GUI object, and the space it will occupy 
	BeginPage(guiBoxWidth,guiBoxHeight);
	
	// GUI.Box creates the transparent GUI box in the space initialized by the BeginPage function
	// The first two variables of Rect are additional spacing (width, height) in the GUI box
	GUI.Box (Rect (0,0,guiBoxWidth,guiBoxHeight), "Game Overview");
	
	// x, y, width, height, dialogue
	 
	
	for (var tutorial in tutorials) {
		GUILayout.Label(tutorial);
	}
	for (var tutorial in tutorialcons) {
		GUILayout.Label(tutorial);
	}
	EndPage();
}*/
 
function ShowCredits() {
	BeginPage(300,300);
	
	for (var credit in credits) {
		GUILayout.Label(credit);
	}
	for (var credit in crediticons) {
		GUILayout.Label(credit);
	}
	EndPage();
}

function ShowTest() {
	BeginPage(300,300);
	GUILayout.Label ("Are you sure?");
	if(GUILayout.Button("Yes")){
		Application.LoadLevel(0);
	}
	if(GUILayout.Button("No")){
		currentPage = Page2.Main;
	}
	EndPage();
}

function ShowQuit() {
	BeginPage(300,300);
	GUILayout.Label ("Are you sure?");
	if(GUILayout.Button("Yes")){
		Application.Quit();
	}
	if(GUILayout.Button("No")){
		currentPage = Page2.Main;
	}
	EndPage();
}
 
function ShowBackButton() {
	if (GUI.Button(Rect(20,Screen.height-50,50,20),"Back")) {
		currentPage = Page2.Main;
	}
}
 
 
function ShowDevice() {
	GUILayout.Label ("Unity player version "+Application.unityVersion);
	GUILayout.Label("Graphics: "+SystemInfo.graphicsDeviceName+" "+
	SystemInfo.graphicsMemorySize+"MB\n"+
	SystemInfo.graphicsDeviceVersion+"\n"+
	SystemInfo.graphicsDeviceVendor);
	GUILayout.Label("Shadows: "+SystemInfo.supportsShadows);
	GUILayout.Label("Image Effects: "+SystemInfo.supportsImageEffects);
	GUILayout.Label("Render Textures: "+SystemInfo.supportsRenderTextures);
}
 
function Qualities() {
        GUILayout.Label(QualitySettings.names[QualitySettings.GetQualityLevel()]);
}
 
function QualityControl() {
	GUILayout.BeginHorizontal();
	if (GUILayout.Button("Decrease")) {
		QualitySettings.DecreaseLevel();
	}
	if (GUILayout.Button("Increase")) {
		QualitySettings.IncreaseLevel();
	}
	GUILayout.EndHorizontal();
}
 
function VolumeControl() {
	GUILayout.Label("Volume");
	AudioListener.volume = GUILayout.HorizontalSlider(AudioListener.volume,0.0,1.0);
}
 
function StatControl() {
	GUILayout.BeginHorizontal();
	showfps = GUILayout.Toggle(showfps,"FPS");
	showtris = GUILayout.Toggle(showtris,"Triangles");
	showvtx = GUILayout.Toggle(showvtx,"Vertices");
	showfpsgraph = GUILayout.Toggle(showfpsgraph,"FPS Graph");
	GUILayout.EndHorizontal();
}
 
function FPSUpdate() {
	var delta = Time.smoothDeltaTime;
		if (!IsGamePaused() && delta !=0.0) {
			fps = 1 / delta;
		}
}
 
function ShowStatNums() {
	GUILayout.BeginArea(Rect(Screen.width-100,10,100,200));
	if (showfps) {
		var fpsString= fps.ToString ("#,##0 fps");
		GUI.color = Color.Lerp(lowFPSColor, highFPSColor,(fps-lowFPS)/(highFPS-lowFPS));
		GUILayout.Label (fpsString);
	}
	if (showtris || showvtx) {
		GetObjectStats();
		GUI.color = statColor;
	}
	if (showtris) {
		GUILayout.Label (tris+"tri");
	}
	if (showvtx) {
		GUILayout.Label (verts+"vtx");
	}
	GUILayout.EndArea();
}
 
function BeginPage(width,height) {
	GUILayout.BeginArea(Rect((Screen.width-width)/2,(Screen.height-height)/2,width,height));
}
 
function EndPage() {
	GUILayout.EndArea();
	if (currentPage != Page2.Main) {
		ShowBackButton();
	}
}
 
function IsBeginning() {
	return Time.time < startTime;
}
 
 
function PauseMenu() {  // When menu is paused, display these options
	BeginPage(200,200);
	if (GUILayout.Button (IsBeginning() ? "Play" : "Continue")) {
		UnPauseGame();
	}
	if (GUILayout.Button ("Tutorial")){
	 	currentPage 	 = Page2.Tutorial;
	}
	if (GUILayout.Button ("Options")) {
		currentPage = Page2.Options;
	}
	if (GUILayout.Button ("Credits")) {
		currentPage = Page2.Credits;
	}
		if (GUILayout.Button ("Main Menu")){
		currentPage = Page2.Test;
	}
	if (GUILayout.Button ("Quit Game")){
		currentPage = Page2.Quit;
	}
	if (IsBrowser() && !IsBeginning() && GUILayout.Button ("Restart")) {
		Application.OpenURL(url);
	}
	EndPage();
}
 
function GetObjectStats() {
	verts = 0;
	tris = 0;
	var ob = FindObjectsOfType(GameObject);
	for (var obj in ob) {
		GetObjectStats(obj);
	}
}
 
function GetObjectStats(object) {
	var filters : Component[];
	filters = object.GetComponentsInChildren(MeshFilter);
	for( var f : MeshFilter in filters )
	{
    	tris += f.sharedMesh.triangles.Length/3;
  		verts += f.sharedMesh.vertexCount;
	}
}
 
function PauseGame() {
	savedTimeScale = Time.timeScale;
	Time.timeScale = 0;
	AudioListener.pause = true;
	if (pauseFilter) pauseFilter.enabled = true;
	currentPage = Page2.Main;
}

// This pause is only called when the game starts, its purpose is to only display the game objectives
function IntroPause(){
	savedTimeScale = Time.timeScale;
	Time.timeScale = 0;
	AudioListener.pause = true;
	if (pauseFilter) pauseFilter.enabled = true;
	
 }
 
function UnPauseGame() {
	Time.timeScale = savedTimeScale;
	AudioListener.pause = false;
	if (pauseFilter) pauseFilter.enabled = false;
	currentPage = Page2.None;
	if (IsBeginning() && start != null) {
		start.active = true;
	}
}

function Update(){
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

function IsGamePaused() {
	return Time.timeScale==0;
}
 
function OnApplicationPause(pause:boolean) {
	if (IsGamePaused()) {
		AudioListener.pause = true;
	}
}