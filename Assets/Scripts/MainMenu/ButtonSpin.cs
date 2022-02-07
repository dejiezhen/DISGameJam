using UnityEngine;
using EasyUI.PickerWheelUI;   //required
using UnityEngine.UI;

public class ButtonSpin : MonoBehaviour
{
	// Reference to the PickerWheel GameObject (step 3):
	[SerializeField] 
	private PickerWheel pickerWheel;

	private void Start()
	{
		// Start spinning:
		//pickerWheel.Spin();
	}
}
