using UnityEngine;
using System.Collections;

public class UnitychanCtrl : MonoBehaviour
{

    private Animator animator;
    // Use this for initialization

    bool is_once = false;

    bool on_up = false;
    bool on_right = false;
    bool on_left = false;
    bool on_down = false;

    //壁判定
    //bool is_kabe = false;

	bool gameOver = false;

    void Start()
    {
        animator = GetComponent<Animator>();
		gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position.y < 90.0f) {
			FadeManager.Instance.LoadLevel ("GameOver", 0.5f);
		}

        if (Input.GetKeyDown("up"))
        {
            on_up = true;
        }
        if (Input.GetKeyDown("right"))
        {
            on_right = true;
        }
        if (Input.GetKeyDown("left"))
        {
            on_left = true;
        }
        if (Input.GetKeyDown("down"))
        {
            on_down = true;
        }

        if (Input.GetKey("up") && (on_right & on_left & on_down) == false )
        {
            if (is_once == false)
            {
                Vector3 next = new Vector3(0, 0, 0);
                Vector3 diff = transform.rotation.eulerAngles - next;

                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - diff);

                is_once = true;
            }

            transform.position += transform.forward * 0.01f;
            animator.SetBool("is_running", true);

        }
        else if (Input.GetKey("right") && (on_up & on_left & on_down) == false)
        {
            if (is_once == false )
            {
                Vector3 next = new Vector3(0, 90, 0);
                Vector3 diff = transform.rotation.eulerAngles - next;

                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - diff);
                is_once = true;
            }
            transform.position += transform.forward * 0.01f;
            animator.SetBool("is_running", true);

        }
        else if (Input.GetKey("left") && (on_right & on_up & on_down) == false)
        {
            if (is_once == false)
            {
                Vector3 next = new Vector3(0, -90, 0);
                Vector3 diff = transform.rotation.eulerAngles - next;

                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - diff);
                is_once = true;
            }
            transform.position += transform.forward * 0.01f;
            animator.SetBool("is_running", true);
        }
        else if (Input.GetKey("down") && (on_right & on_left & on_up) == false)
        {
            if (is_once == false)
            {
                Vector3 next = new Vector3(0, 180, 0);
                Vector3 diff = transform.rotation.eulerAngles - next;

                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - diff);
                is_once = true;
            }
            transform.position += transform.forward * 0.01f;
            animator.SetBool("is_running", true);

        }
        else
        {
            animator.SetBool("is_running", false);
            is_once = false;
        }

        if (Input.GetKeyUp("up"))
        {
            on_up = false;
        }
        if (Input.GetKeyUp("right"))
        {
            on_right = false;
        }
        if (Input.GetKeyUp("left"))
        {
            on_left = false;
        }
        if (Input.GetKeyUp("down"))
        {
            on_down = false;
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Rigidbody rb = GetComponent<Rigidbody>();
    //    rb.isKinematic = false;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    Rigidbody rb = GetComponent<Rigidbody>();
    //    rb.isKinematic = true;
    //}

	void Watched () {
		if (!gameOver) {
			gameOver = true;
			FadeManager.Instance.LoadLevel ("GameOver", 0.5f);
		}
	}
}
