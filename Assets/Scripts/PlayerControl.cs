using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.


	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.
    public float jumpIncrement = 20f;        //Jump higher the longer you hold.
    public float jumpForceCap = 1500;        //But not too high.
	
    public AudioClip[] taunts;				// Array of clips for when the player taunts.
	public float tauntProbability = 50f;	// Chance of a taunt happening.
	public float tauntDelay = 1f;			// Delay for when the taunt should happen.
	public bool isControlEnabled=true;



	private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
	private float stackTimeCount=0;
	private bool gaveInput=true;

    private bool jumpCapReached = false;
    private bool extraJumpForce = false;
    
	public enum ControlStates{None,MoveInPlace,Free}

	public ControlStates controlState = ControlStates.None;

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
        if (Camera.main.GetComponent<GameController>().ShowTutorial)
	    {
            transform.position = new Vector3(5, 1, 0);
	    }
        
	}


	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		Grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        
        //if you land on the ground the jumpCap resets.
        if (grounded)
        {
            jumpCapReached = false;
        }

		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown("Jump") && Grounded)
			jump = true;


        if (Input.GetButton("Jump") && !Grounded && !jumpCapReached) // && !Grounded)
        {
            Debug.Log("Adding force");
            extraJumpForce = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
            jumpCapReached = true;
        }

	}

	public bool Grounded {
		get {
			return grounded;
		}
		set {
			anim.SetBool("Grounded",value);
			grounded = value;
		}
	}

	void FixedUpdate ()
	{

		if(controlState == ControlStates.None)
			return;

		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");

		gaveInput= (h!=0);

		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			Flip();

		if(controlState == ControlStates.MoveInPlace)
			return;

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		anim.SetFloat("Speed", Mathf.Abs(h));

		if(Grounded){
			stackTimeCount=0;
			gaveInput=false;
		}
		else{
			if(Mathf.Round(rigidbody2D.velocity.x)==0 && gaveInput)
				stackTimeCount+=Time.deltaTime;
		}

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed && stackTimeCount<0.05f)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * moveForce);

		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);


		// If the player should jump...
		if(jump)
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");

			// Play a random jump audio clip.
			int i = Random.Range(0, jumpClips.Length);
			AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}


        Debug.Log("Velo " + rigidbody2D.velocity);
        if (rigidbody2D.velocity.y > jumpForceCap)
        {
            jumpCapReached = true;
        }
        //if were still junmping
        if (!jumpCapReached && extraJumpForce && rigidbody2D.velocity.y <= jumpForceCap && rigidbody2D.velocity.y > 0)
        {
            rigidbody2D.AddForce(new Vector2(0f,jumpIncrement));
            extraJumpForce = false;
        }
	}
	
	
	void Flip ()
	{
		stackTimeCount=0;
		gaveInput=false;

		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	public IEnumerator Taunt()
	{
		// Check the random chance of taunting.
		float tauntChance = Random.Range(0f, 100f);
		if(tauntChance > tauntProbability)
		{
			// Wait for tauntDelay number of seconds.
			yield return new WaitForSeconds(tauntDelay);

			// If there is no clip currently playing.
			if(!audio.isPlaying)
			{
				// Choose a random, but different taunt.
				tauntIndex = TauntRandom();

				// Play the new taunt.
				audio.clip = taunts[tauntIndex];
				audio.Play();
			}
		}
	}


	int TauntRandom()
	{
		// Choose a random index of the taunts array.
		int i = Random.Range(0, taunts.Length);

		// If it's the same as the previous taunt...
		if(i == tauntIndex)
			// ... try another random taunt.
			return TauntRandom();
		else
			// Otherwise return this index.
			return i;
	}
}
