using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class controller_enableSituation : MonoBehaviour {

	public int nowLevel = 0;
	public static controller_enableSituation thisSit;

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
//	public playerInfo thisLevelPlayerInfo;
	public enemyInfo thisLevelEnemyInfo;
	public levelInfo(enemyInfo newEnemyInfo){
		thisLevelEnemyInfo = newEnemyInfo;
	}
}

[System.Serializable]
public class enemyInfo{
	public int startAfterSec = 10;
	public int healthPoint = 10;
	public float hitWaitSec = 1;
	public float hitInterval = 5;
	public float hitRange = 10;
	public float speed = 10;
	[Range(0,50)]
	public int typeRed;
	[Range(0,50)]
	public int typeYellow;
	[Range(0,50)]
	public int typeBlue;
	public enemyInfo(int newStart,float nSpeed ,int newHealth,float nHitWaitSec ,float newHitInter,float newRange,int nTypeRed,int nTypeYellow,int nTypeblue){
		startAfterSec = newStart;
		healthPoint = newHealth;
		hitInterval = newHitInter;
		hitRange = newRange;
		typeRed = nTypeRed;
		typeBlue = nTypeblue;
		typeYellow = nTypeYellow;
		hitWaitSec = nHitWaitSec;
		speed = nSpeed;
	}

	public enemyInfo(enemyInfo clone){
		startAfterSec = clone.startAfterSec;
		healthPoint = clone.healthPoint;
		hitInterval = clone.hitInterval;
		hitRange = clone.hitRange;
		typeRed = clone.typeRed;
		typeBlue = clone.typeBlue;
		typeYellow = clone.typeYellow;
		hitWaitSec = clone.hitWaitSec;
		speed = clone.speed;
	}
}

[System.Serializable]
public class playerInfo{
	public type defaultPaint = type.red;
	public playerInfo(type newDe){
		defaultPaint = newDe;
	}
}
//	public type beginingColor;
//	public int totalPower;
//	public bool enableToMixColor;
//	public bool enableToCreateAI;
//	public bool enableRed;
//	public bool enableBlue;
//	public bool enableGreen;
//	public playerInfo(type newBegin,int newPw,bool newMix,bool newAI,bool newR, bool newB, bool newG){
//		beginingColor = newBegin;
//		totalPower = newPw;
//		enableToMixColor = newMix;
//		enableToCreateAI = newAI;
//		enableRed = newR;
//		enableBlue = newB;
//		enableGreen = newG;
//	}
//}