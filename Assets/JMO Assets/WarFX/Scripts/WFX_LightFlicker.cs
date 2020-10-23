using UnityEngine;
using System.Collections;

/**
 *	Rapidly sets a light on/off.
 *	
 *	(c) 2015, Jean Moreno
**/

[RequireComponent(typeof(Light))]
public class WFX_LightFlicker : MonoBehaviour
{
	public float duration = 0.50f;
	public bool flashing = false;
	public float time = 0.05f;
	
	private float timer;
	
	void Start ()
	{
		timer = time;
		StartCoroutine("Flicker");
	}
	
	IEnumerator Flicker()
	{
		flashing = true;
		while(flashing)
		{
			GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
			
			do
			{
				timer -= Time.deltaTime;
				yield return null;
			}
			while(timer > 0);
			timer = time;
		}
		yield return new WaitForSeconds(1);
		flashing = false;
	}
}
