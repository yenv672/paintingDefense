using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class controller_enableSituation : MonoBehaviour {

	public int nowLevel = 0;
	public static controller_enableSituation thisSit;
	//public bool enableMixing = false;




	public List<levelInfo> level_assign = new List<levelInfo>();

	void Awake(){
		thisSit = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
[System.Serializable]
public class levelInfo{
	public playerInfo thisLevelPlayerInfo;
	public enemyInfo thisLevelEnemyInfo;
	public levelInfo(playerInfo newPlayerInfo,enemyInfo newEnemyInfo){
		thisLevelPlayerInfo = newPlayerInfo;
		thisLevelEnemyInfo= newEnemyInfo;
	}
}
[System.Serializable]
public class playerInfo{
	public type beginingColor;
	public int totalPower;
	public bool enableToMixColor;
	public bool enableToCreateAI;
	public bool enableRed;
	public bool enableBlue;
	public bool enableGreen;
	public playerInfo(type newBegin,int newPw,bool newMix,bool newAI,bool newR, bool newB, bool newG){
		beginingColor = newBegin;
		totalPower = newPw;
		enableToMixColor = newMix;
		enableToCreateAI = newAI;
		enableRed = newR;
		enableBlue = newB;
		enableGreen = newG;
	}
}
[System.Serializable]
public class enemyInfo{
	public float startGenerateAfterSec;
	public float waveIntervalSec;
	public int[] generateHowMuch;
	[Range(0,10)]
	public int typeRed;
	[Range(0,10)]
	public int typeGreen;
	[Range(0,10)]
	public int typeBlue;
	[Range(0,10)]
	public int typeYellow;
	[Range(0,10)]
	public int typeMage;
	[Range(0,10)]
	public int typeCyan;

	public enemyInfo(float newStart,float newWaveSec,int[] newGenerAmount,
		int newRed,int newGreen, int newBlue, int newYellow,
		int newMage, int newCyan){
		startGenerateAfterSec = newStart;
		waveIntervalSec = newWaveSec;
		generateHowMuch = newGenerAmount;
		typeRed = newRed;
		typeBlue =newBlue;
		typeGreen = newGreen;
		typeYellow = newYellow;
		typeMage = newMage;
		typeCyan = newCyan;
	}
}