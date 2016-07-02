using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ExamSeeker : MonoBehaviour {

	public float speed = 3;
	public float DamagePerSecond = 10;

	public bool isMoving = true;

	private ExamSheet exam;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var body = GetComponent<Rigidbody2D> ();

		if (isMoving) {
			body.velocity = Vector2.left * speed;
		} else {
			body.velocity = Vector2.zero;
		}

		if (exam != null) {
			var unit = exam.GetComponent<Unit> ();
			var dmgInfo = new DamageInfo ();
			dmgInfo.Value = DamagePerSecond * Time.deltaTime;
			unit.Damage (dmgInfo);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		var go = collider.gameObject;
		exam = go.GetComponent<ExamSheet> ();
		if (exam != null) {
			OnHitExamSheet();
		}
	}

	void OnHitExamSheet() {
		isMoving = false;
		print ("collided with exam!");
	}

	void OnTriggerExit2D(Collider2D collider) {
		
		
	}
}
