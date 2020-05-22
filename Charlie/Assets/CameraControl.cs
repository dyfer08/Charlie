using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraControl : MonoBehaviour{

	[SerializeField]
	Camera Camera;
	[SerializeField]
	Transform CameraPivot;
	[SerializeField]
	Image Overlay;

	void Start(){
		Overlay.DOFade(0, 5);
	}

    void Update(){

    	// Contrôles Zoom
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			Camera.DOKill();
			Camera.DOOrthoSize(1, 2).SetSpeedBased().SetEase(Ease.InOutQuad);
		}
		if(Input.GetKeyUp(KeyCode.UpArrow)){
			if(!Input.GetKey(KeyCode.DownArrow))
			Camera.DOKill();
		}

		if(Input.GetKeyDown(KeyCode.DownArrow)){
			Camera.DOKill();
			Camera.DOOrthoSize(6, 2).SetSpeedBased().SetEase(Ease.InOutQuad);
		}

    	if(Input.GetKeyUp(KeyCode.DownArrow)){
    		if(!Input.GetKey(KeyCode.UpArrow))
			Camera.DOKill();
		}


		// Contrôles Rotation
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			CameraPivot.DOKill();
			CameraPivot.DOLocalRotate(new Vector3(0,360,0), 50, RotateMode.LocalAxisAdd).SetSpeedBased().SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Restart);
		}
		
		if(Input.GetKeyUp(KeyCode.LeftArrow)){
			if(!Input.GetKey(KeyCode.RightArrow))
			CameraPivot.DOKill();
		}

		if(Input.GetKeyDown(KeyCode.RightArrow)){
			CameraPivot.DOKill();
			CameraPivot.DOLocalRotate(new Vector3(0,-360,0), 50, RotateMode.LocalAxisAdd).SetSpeedBased().SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Restart);
		}

    	if(Input.GetKeyUp(KeyCode.RightArrow)){
    		if(!Input.GetKey(KeyCode.LeftArrow))
			CameraPivot.DOKill();
		}
        
    }
}
