using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	
	public GUITexture MG_Equip;
	public GUITexture AOE_Equip;
	public GUITexture AOE_Full;
	public GUITexture AOE_75;
	public GUITexture AOE_50;
	public GUITexture AOE_25;
	public GUITexture MG_Full;
	public GUITexture MG_90;
	public GUITexture MG_80;
	public GUITexture MG_70;
	public GUITexture MG_60;
	public GUITexture MG_50;
	public GUITexture MG_40;
	public GUITexture MG_30;
	public GUITexture MG_20;
	public GUITexture MG_10;
	
	// Use this for initialization
	void Start () {
		MG_Equip.enabled = false;
		AOE_Equip.enabled = false;
		AOE_Full.enabled = false;
		AOE_75.enabled = false;
		AOE_50.enabled = false;
		AOE_25.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(MGWeapon.mgAmmo > 0){
			MG_Equip.enabled = true;
		}
		if(MGWeapon.mgAmmo == 0){
			MG_Equip.enabled = false;
		}
		if(AOEWeapon.aoeAmmo == 4){
			AOE_Equip.enabled = true;
			AOE_Full.enabled = true;
		}
		if(AOEWeapon.aoeAmmo < 4){
			AOE_Equip.enabled = false;
		}
		if(AOEWeapon.aoeAmmo == 3){
			AOE_Full.enabled = false;
			AOE_75.enabled = true;
			AOE_50.enabled = false;
			AOE_25.enabled = false;
		}
		if(AOEWeapon.aoeAmmo == 2){
			AOE_Full.enabled = false;
			AOE_75.enabled = false;
			AOE_50.enabled = true;
			AOE_25.enabled = false;
		}
		if(AOEWeapon.aoeAmmo == 1){
			AOE_Full.enabled = false;
			AOE_75.enabled = false;
			AOE_50.enabled = false;
			AOE_25.enabled = true;
		}
		if(AOEWeapon.aoeAmmo == 0){
			AOE_Full.enabled = false;
			AOE_75.enabled = false;
			AOE_50.enabled = false;
			AOE_25.enabled = false;
		}
		if(MGWeapon.mgAmmo == 200 && WeaponHandler.mgSelected == true){
			MG_Full.enabled = true;
			MG_90.enabled = false;
			MG_80.enabled = false;
			MG_70.enabled = false;
			MG_60.enabled = false;
			MG_50.enabled = false;
			MG_40.enabled = false;
			MG_30.enabled = false;
			MG_20.enabled = false;
			MG_10.enabled = false;
		}
		if(MGWeapon.mgAmmo < 200 && MGWeapon.mgAmmo >= 180 && WeaponHandler.mgSelected == true){
			MG_Full.enabled = false;
			MG_90.enabled = true;
			MG_80.enabled = false;
			MG_70.enabled = false;
			MG_60.enabled = false;
			MG_50.enabled = false;
			MG_40.enabled = false;
			MG_30.enabled = false;
			MG_20.enabled = false;
			MG_10.enabled = false;
		}
		if(MGWeapon.mgAmmo < 180 && MGWeapon.mgAmmo >= 160 && WeaponHandler.mgSelected == true){
			MG_Full.enabled = false;
			MG_90.enabled = false;
			MG_80.enabled = true;
			MG_70.enabled = false;
			MG_60.enabled = false;
			MG_50.enabled = false;
			MG_40.enabled = false;
			MG_30.enabled = false;
			MG_20.enabled = false;
			MG_10.enabled = false;
		}
		if(MGWeapon.mgAmmo < 160 && MGWeapon.mgAmmo >= 140 && WeaponHandler.mgSelected == true){
			MG_Full.enabled = false;
			MG_90.enabled = false;
			MG_80.enabled = false;
			MG_70.enabled = true;
			MG_60.enabled = false;
			MG_50.enabled = false;
			MG_40.enabled = false;
			MG_30.enabled = false;
			MG_20.enabled = false;
			MG_10.enabled = false;
		}
		if(MGWeapon.mgAmmo < 140 && MGWeapon.mgAmmo >= 120 && WeaponHandler.mgSelected == true){
			MG_Full.enabled = false;
			MG_90.enabled = false;
			MG_80.enabled = false;
			MG_70.enabled = false;
			MG_60.enabled = true;
			MG_50.enabled = false;
			MG_40.enabled = false;
			MG_30.enabled = false;
			MG_20.enabled = false;
			MG_10.enabled = false;
		}
		if(MGWeapon.mgAmmo < 120 && MGWeapon.mgAmmo >= 100 && WeaponHandler.mgSelected == true){
			MG_Full.enabled = false;
			MG_90.enabled = false;
			MG_80.enabled = false;
			MG_70.enabled = false;
			MG_60.enabled = false;
			MG_50.enabled = true;
			MG_40.enabled = false;
			MG_30.enabled = false;
			MG_20.enabled = false;
			MG_10.enabled = false;
		}
		if(MGWeapon.mgAmmo < 100 && MGWeapon.mgAmmo >= 80 && WeaponHandler.mgSelected == true){
			MG_Full.enabled = false;
			MG_90.enabled = false;
			MG_80.enabled = false;
			MG_70.enabled = false;
			MG_60.enabled = false;
			MG_50.enabled = false;
			MG_40.enabled = true;
			MG_30.enabled = false;
			MG_20.enabled = false;
			MG_10.enabled = false;
		}
		if(MGWeapon.mgAmmo < 80 && MGWeapon.mgAmmo >= 60 && WeaponHandler.mgSelected == true){
			MG_Full.enabled = false;
			MG_90.enabled = false;
			MG_80.enabled = false;
			MG_70.enabled = false;
			MG_60.enabled = false;
			MG_50.enabled = false;
			MG_40.enabled = false;
			MG_30.enabled = true;
			MG_20.enabled = false;
			MG_10.enabled = false;
		}
		if(MGWeapon.mgAmmo < 60 && MGWeapon.mgAmmo >= 40 && WeaponHandler.mgSelected == true){
			MG_Full.enabled = false;
			MG_90.enabled = false;
			MG_80.enabled = false;
			MG_70.enabled = false;
			MG_60.enabled = false;
			MG_50.enabled = false;
			MG_40.enabled = false;
			MG_30.enabled = false;
			MG_20.enabled = true;
			MG_10.enabled = false;
		}
		if(MGWeapon.mgAmmo < 40 && MGWeapon.mgAmmo >= 0 && WeaponHandler.mgSelected == true){
			MG_Full.enabled = false;
			MG_90.enabled = false;
			MG_80.enabled = false;
			MG_70.enabled = false;
			MG_60.enabled = false;
			MG_50.enabled = false;
			MG_40.enabled = false;
			MG_30.enabled = false;
			MG_20.enabled = false;
			MG_10.enabled = true;
		}
		if(MGWeapon.mgAmmo == 0 && WeaponHandler.mgSelected == true){
			MG_Full.enabled = false;
			MG_90.enabled = false;
			MG_80.enabled = false;
			MG_70.enabled = false;
			MG_60.enabled = false;
			MG_50.enabled = false;
			MG_40.enabled = false;
			MG_30.enabled = false;
			MG_20.enabled = false;
			MG_10.enabled = false;
		}
		if(WeaponHandler.mgSelected == false){
			MG_Full.enabled = false;
			MG_90.enabled = false;
			MG_80.enabled = false;
			MG_70.enabled = false;
			MG_60.enabled = false;
			MG_50.enabled = false;
			MG_40.enabled = false;
			MG_30.enabled = false;
			MG_20.enabled = false;
			MG_10.enabled = false;
		}
	}
}
