using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class UnitychanCtrl : MonoBehaviour
{
    public GameObject camera;

    private Animator animator;
    // Use this for initialization

    bool is_once = false;

    bool on_up = false;
    bool on_right = false;
    bool on_left = false;
    bool on_down = false;

	bool gameOver = false;

	private float satiety = 100f;
	public float satietyDecrease_perMeter = 10.0f;
	private Vector3 prevPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
		gameOver = false;
		prevPosition = transform.position;
		satiety = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        CameraCtrl camCtrl = camera.GetComponent<CameraCtrl>();

		if (transform.position.y < 90.0f && !gameOver) {
			gameOver = true;
			FadeManager.Instance.LoadLevel ("GameOver", 0.5f);
		}

		satiety -= Mathf.Sqrt ((transform.position - prevPosition).sqrMagnitude) * satietyDecrease_perMeter;
		prevPosition = transform.position;
		if (satiety <= 0f && !gameOver) {
			gameOver = true;
			FadeManager.Instance.LoadLevel ("GameOver", 0.5f);
		}

        /////ジョイスティック制御
        // 右・左
        float vj_x = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        // 上・下
        float vj_y = CrossPlatformInputManager.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2(vj_x, vj_y).normalized;

        //Debug.Log("Move:" + direction.ToString());

        if (Input.GetKey("up") || vj_y >= 0.5f)
        {
            on_up = true;
            on_down = false;
            on_right = false;
            on_left = false;
            is_once = false;
            //Debug.Log("Key:Up");
        }
        if (Input.GetKey("right") || vj_x >= 0.5f)
        {
            on_up = false;
            on_down = false;
            on_right = true;
            on_left = false;
            is_once = false;
            //Debug.Log("Key:Right");
        }
        if (Input.GetKey("left") || vj_x <= -0.5f)
        {
            on_up = false;
            on_down = false;
            on_right = false;
            on_left = true;
            is_once = false;
            //Debug.Log("Key:Left");
        }
        if (Input.GetKey("down") || vj_y <= -0.5f)
        {
            on_up = false;
            on_down = true;
            on_right = false;
            on_left = false;
            is_once = false;
            //Debug.Log("Key:Down");
        }

        if (on_up && (on_right & on_left & on_down) == false )
        {
            if (is_once == false)
            {
                if (camCtrl.quoter)
                {
                    Vector3 next = new Vector3(0, 0, 0);
                    Vector3 diff = transform.rotation.eulerAngles - next;

                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - diff);
                    is_once = true;
                }
            }

            transform.position += transform.forward * 0.01f;
            animator.SetBool("is_running", true);

        }
        else if (on_right && (on_up & on_left & on_down) == false)
        {
            if (is_once == false )
            {
                if (camCtrl.quoter)
                {
                    Vector3 next = new Vector3(0, 90, 0);
                    Vector3 diff = transform.rotation.eulerAngles - next;

                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - diff);
                    is_once = true;

                    transform.position += transform.forward * 0.01f;
                    animator.SetBool("is_running", true);
                }
            }

            if (camCtrl.quoter == false)
            {
                Vector3 next = new Vector3(0, 3, 0);
                transform.Rotate(next);
                is_once = true;
            }
        }
        else if (on_left && (on_right & on_up & on_down) == false)
        {
            if (is_once == false)
            {
                if (camCtrl.quoter)
                {
                    Vector3 next = new Vector3(0, -90, 0);
                    Vector3 diff = transform.rotation.eulerAngles - next;

                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - diff);
                    is_once = true;

                    transform.position += transform.forward * 0.01f;
                    animator.SetBool("is_running", true);
                }
            }

            if(camCtrl.quoter == false)
            {
                Vector3 next = new Vector3(0, -3, 0);
                transform.Rotate(next);
                is_once = true;
            }
        }
        else if (on_down && (on_right & on_left & on_up) == false)
        {
            if (is_once == false)
            {
                if (camCtrl.quoter)
                {

                    Vector3 next = new Vector3(0, 180, 0);
                    Vector3 diff = transform.rotation.eulerAngles - next;

                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - diff);
                    is_once = true;

                    transform.position += transform.forward * 0.01f;
                    animator.SetBool("is_running", true);
                }
            }
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

        //十字キーが押されておらず、バーチャルパットもニュートラルなら停止する
        if (
                (
                    Input.GetKey("up")
                    || Input.GetKey("right")
                    || Input.GetKey("left")
                    || Input.GetKey("down")
                ) == false
                && (vj_x == 0.0f && vj_y == 0.0f)
            )
        {
            on_up = false;
            on_down = false;
            on_left = false;
            on_right = false;
            Debug.Log("AllStop");
        }

    }

	void Watched () {
		if (!gameOver) {
			gameOver = true;
			FadeManager.Instance.LoadLevel ("GameOver", 0.5f);
		}
	}
	public float Satiety {
		get {
			return satiety;
		}
        set {
            satiety = value;
        }
	}
}
