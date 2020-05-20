using System.Collections;
using UnityEngine;
using System;
using UnityEngine.VFX;
using TMPro;

public class Sculpture : MonoBehaviour{

	private DateTime BirthTime = DateTime.Parse("2020/05/19 00:09:00");
	[SerializeField]
	private TimeSpan Age;
	[SerializeField]
	private int AgeInHours = 0;
	[SerializeField]
	VisualEffect VFXSculpture;

	IEnumerator Start(){

		// Calculer le nombre de points initial
		Age = DateTime.Now - BirthTime;
		AgeInHours = (int)Age.TotalHours;

		VFXSculpture.SetInt("Dots", AgeInHours);
		VFXSculpture.SendEvent("Update");

		// Ajouter un point à 09 de l'heure en cours ou la prochaine
		float MinutesToWait = 0;
		if(int.Parse(System.DateTime.Now.ToString("mm")) >= 26){
			MinutesToWait = 60 - int.Parse(System.DateTime.Now.ToString("mm")) + 26;
			yield return new WaitForSeconds(MinutesToWait * 60);
		}else{
			MinutesToWait = 26 - int.Parse(System.DateTime.Now.ToString("mm"));
			yield return new WaitForSeconds(MinutesToWait * 60);
		}
		AgeInHours ++;

		// Ajouter un point toutes les heures
		while(true){
			yield return new WaitForSeconds(3600);
			AgeInHours ++;
		}
    }
}
