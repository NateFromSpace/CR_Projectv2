using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerController player;

	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float respawnDelay;

	private float gravityStore;

	public int pointPenaltyOnDeath;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.renderer.enabled = false;
		gravityStore = player.rigidbody2D.gravityScale;
		player.rigidbody2D.gravityScale = 0f;
		player.rigidbody2D.velocity = Vector2.zero;
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		Debug.Log("Player Respawn");
		yield return new WaitForSeconds (respawnDelay);
		player.rigidbody2D.gravityScale = gravityStore;
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		player.renderer.enabled = true;
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}
