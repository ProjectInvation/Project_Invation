#pragma strict


function Update () {
	if(Input.GetKey(KeyCode.D))
	{
	if(transform.rotation.y < 0){transform.rotation.y *= -1;}
	transform.position.x += 0.05;
	}
	else if(Input.GetKey(KeyCode.A))
	{
	if(transform.rotation.y > 0){transform.rotation.y *= -1;}
	transform.position.x -= 0.05;
	}

	if(transform.position.x > 20){transform.position.x = -19;}
	else if(transform.position.x < -20){transform.position.x = 19;}
	
}


function OnTriggerEnter (col:Collider) {        
	
	if(col.gameObject.tag == "enemy")
	{
		transform.position.z = -2;
	}
}