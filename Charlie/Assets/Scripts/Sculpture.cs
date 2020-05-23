using System.Collections;
using System.Collections.Generic;
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
	List<VisualEffect> VFXSculptures;
	[SerializeField]
	TextMeshProUGUI Infos;

	IEnumerator Start(){

		// Calculer le nombre de points initial
		Age = DateTime.Now - BirthTime;
		AgeInHours = (int)Age.TotalHours;

		UpdateSculptures(AgeInHours);

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
		UpdateSculptures(1);

		// Ajouter un point toutes les heures
		while(true){
			yield return new WaitForSeconds(3600);
			AgeInHours ++;
			UpdateSculptures(1);
		}
    }

    void UpdateSculptures(int DotsQuantity){
    	for (int i=0; i<VFXSculptures.Count; i++){
			VFXSculptures[i].SetInt("Dots", DotsQuantity);
			VFXSculptures[i].SendEvent("Update");
		}
		Infos.text = DotsQuantity+" H  .  "+ (DotsQuantity*3) +" PTS";
    }

    void Update(){
    	if(Input.GetKeyDown(KeyCode.A)){
    		for (int i=0; i<VFXSculptures.Count; i++){
				VFXSculptures[i].Reinit();
			}
    		UpdateSculptures(AgeInHours);
		}

		if(Input.GetKeyDown(KeyCode.Z)){
			for (int i=0; i<VFXSculptures.Count; i++){
				VFXSculptures[i].Reinit();
			}
    		UpdateSculptures(43800);
		}

		if(Input.GetKeyDown(KeyCode.E)){
			for (int i=0; i<VFXSculptures.Count; i++){
				VFXSculptures[i].Reinit();
			}
    		UpdateSculptures(219000);
		}

		if(Input.GetKeyDown(KeyCode.R)){
			for (int i=0; i<VFXSculptures.Count; i++){
				VFXSculptures[i].Reinit();
			}
    		UpdateSculptures(876000);
		}
    }
}
