using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
public class type_Atk : MonoBehaviour {

	public Material dis;
	public enemyInfo myInfo;
	public Transform playerPosition;
	public Transform movingPosition;
//	public GameObject projectionObj;
	public type atkType;
	public NavMeshAgent agent;
	public LayerMask hitTHis;
	public List<Renderer> disappear = new List<Renderer>();
	Material originalMat;
	Renderer[] childrenRender;
	Coroutine behaviourCor;
	Coroutine underAttack;
	int lastNum = 0;

	[System.Serializable]
	public class MyEventType : UnityEvent { }
	public MyEventType hurtEvent;
	public MyEventType preAttackEvent;
	public MyEventType attackEvent;
	public MyEventType dieEvent;

	void OnAwake(){
		
	}

	// Use this for initialization
	void Start () {
		childrenRender = GetComponentsInChildren<Renderer> ();
		for (int i = 0; i < childrenRender.Length; i++) {
			disappear.Add (childrenRender [i]);
		}
		originalMat = GetComponentsInChildren<Renderer> () [0].material;
		myInfo = new enemyInfo (controller_enableSituation.thisSit.level_assign[controller_enableSituation.thisSit.nowLevel].thisLevelEnemyInfo);
		agent.speed = myInfo.speed;
		behaviourCor = StartCoroutine (behaviour());
		changeMat (originalMat);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 lookAtHere = new Vector3 (playerPosition.position.x,transform.position.y,playerPosition.position.z);
		transform.LookAt (lookAtHere);
	}

	IEnumerator behaviour(){
		if (underAttack != null) {
			StopCoroutine (underAttack);
			underAttack = null;
		} else {
			yield return new WaitForSeconds (myInfo.startAfterSec);
		}

		while (true) {
			preAtk ();
			yield return new WaitForSeconds (myInfo.hitWaitSec);
			atk ();
			yield return new WaitForSeconds (5);
			move ();
			yield return new WaitForSeconds (2);
			changeMat (originalMat);
			yield return new WaitForSeconds (myInfo.hitInterval);

		}
	}

	void preAtk(){
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit rayhit = new RaycastHit ();
		if (Physics.Raycast (ray, out rayhit, 1000f, hitTHis)) {
//			print (rayhit.point);
//			projectionObj.transform.position = rayhit.point;
//			projectionObj.transform.LookAt (playerPosition);
//			projectionObj.SetActive (true);
			atkType = createInProportion();

		}
		Material thisMat = type_general.thisGeneral.findMat (atkType);
		changeMat (thisMat);
		preAttackEvent.Invoke ();
	}

	void atk(){
		attackEvent.Invoke ();
//		projectionObj.SetActive (false);
		agent.destination = playerPosition.position;

	}

	void move(){
		agent.destination = movingPosition.position;
	}

	public void hurt(){
		if (underAttack == null) {
			hurtEvent.Invoke ();
			print ("hurt"+lastNum);
			myInfo.healthPoint -= 1;
			int temp = lastNum;
			for (int i = lastNum; i < disappear.Count; i++) {
				if (lastNum - temp > 10) {
				} else {
					lastNum++;
					disappear [i].material= dis;
				}
			}
			if (myInfo.healthPoint < 0) Die ();
			StopCoroutine (behaviourCor);
			underAttack = StartCoroutine (escape ());
		}
	}

	IEnumerator escape(){
		print ("escape");
		agent.speed = myInfo.speed * 1.5f;
		agent.destination = movingPosition.position;
		changeMat (originalMat);
		yield return new WaitForSeconds (1);
		agent.speed = myInfo.speed;
		behaviourCor = StartCoroutine (behaviour());

	}

	void changeMat(Material Mat){
		for (int i = 0; i < childrenRender.Length; i++) {
			childrenRender [i].material = Mat;
		}
	}

	public void Die(){
		dieEvent.Invoke ();
		print ("enemy DIE");
	}


	type createInProportion(){
		int red = myInfo.typeRed;
		int yellow = red + myInfo.typeYellow;
		int blue = yellow + myInfo.typeBlue;
		int coin = Random.Range (0, blue);
//		print (coin+" "+blue);
		if (coin < red) {
			myInfo.typeYellow += 1;
			myInfo.typeBlue += 1;
			return type.red;
		} else if (coin < yellow) {
			myInfo.typeRed += 1;
			myInfo.typeBlue += 1;
			return type.yellow;
		} else {
			myInfo.typeRed += 1;
			myInfo.typeYellow += 1;
			return type.blue;
		}
	}

}
