using UnityEngine;
using System.Collections;

public class CharaCtrl3 : MonoBehaviour {

    ////float gravity = 20.0;
    //Vector3 moveDirection = Vector3.zero;

    //// Use this for initialization
    //void Start () {
	
    //}
	
    //// Update is called once per frame
    //void FixedUpdate () {
    //    bool inputH = false;
    //    bool inputV = false;

    //    CharacterController controller = (CharacterController)GetComponent("CharacterController");
    //    moveDirection = Vector3.zero;
    //   // moveDirection.y -= gravity*Time.deltaTime;
    	
    //    if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5) {
    //        inputH = true;
    //        //transform.eulerAngles.y += Input.GetAxis("Horizontal") * 3.0f;
    //    }
    //    if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5) {
    //        inputV = true;
    //        moveDirection += transform.forward * 2.0f;
    //    }
    	
    //    controller.Move(moveDirection*Time.deltaTime);
    	
    //    if (inputH || inputV) {
    //        //animation.CrossFade("walk");
    //    } else {
    //        //animation.CrossFade("idle");
    //    }
    //}
}
