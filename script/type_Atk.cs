using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class type_Atk : MonoBehaviour {

	public enemyInfo myInfo;
	public Transform playerPosition;
	public Transform movingPosition;
	public GameObject projectionObj;
	public type atkType;
	public NavMeshAgent agent;
	public LayerMask hitTHis;
	Material originalMat;
	Renderer[] childrenRender;
	Coroutine behaviourCor;
	Coroutine underAttack;

	[System.Serializable]
	public class MyEventType : UnityEvent { }
	public MyEventType hurtEvent;
	public MyEventType preAttackEvent;
	public MyEventType attackEvent;
	public MyEventType dieEvent;

	// Use this for initialization
	void Start () {
		childrenRender = GetComponentsInChildren<Renderer> ();
		myInfo = new enemyInfo (controller_enableSituation.thisSit.level_assign[controller_enableSituation.thisSit.nowLevel].thisLevelEnemyInfo);
		agent.speed = myInfo.speed;
		behaviourCor = StartCoroutine (behaviour());
		originalMat = GetComponentsInChildren<Renderer> () [0].material;
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
			yield return new WaitForSeconds (myInfo.hitInterval);

		}
	}

	void preAtk(){
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit rayhit = new RaycastHit ();
		if (Physics.Raycast (ray, out rayhit, 1000f, hitTHis)) {
//			print (rayhit.point);
			projectionObj.transform.position = rayhit.point;
			projectionObj.transform.LookAt (playerPosition);
			projectionObj.SetActive (true);
			atkType = createInProportion();

		}
		Material thisMat = type_general.thisGeneral.findMat (atkType);
		changeMat (thisMat);
		preAttackEvent.Invoke ();
	}

	void atk(){
		attackEvent.Invoke ();
		projectionObj.SetActive (false);
		agent.destination = playerPosition.position;

	}

	void move(){
		changeMat (originalMat);
		agent.destination = movingPosition.position;
	}

	public void hurt(){
		if (underAttack == null) {
			hurtEvent.Invoke ();
			print ("hurt");
			myInfo.healthPoint -= 1;
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
