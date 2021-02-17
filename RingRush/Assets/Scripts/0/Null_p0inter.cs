using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Null_p0inter : MonoBehaviour
{
	static public bool easteregg=false;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Ring")
			easteregg = true;
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == "Ring")
			easteregg = false;
	}
}
