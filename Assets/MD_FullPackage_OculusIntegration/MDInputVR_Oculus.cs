using UnityEngine;

namespace MD_Plugin
{
    /// <summary>
    /// Input dependency = Oculus Platform
    /// </summary>
    [AddComponentMenu(MD_Debug.ORGANISATION + MD_Debug.PACKAGENAME + "VR Input/MDInputVR [Oculus Integration]")]
    public class MDInputVR_Oculus : MonoBehaviour
    {
        // VR Target Device
        [Space]
        public OVRInput.Controller targetDevice;

        // VR Input Type
        public OVRInput.Button inputButton;
        [Space]
        [Tooltip("Target object that contains a behaviour with 'GlobalReceived_SetControlInput' method. This method is called if specific VR button is pressed here. Leave this empty if the message receiver is THIS object")]
        public GameObject messageReceiver;
        [Space]
        [Tooltip("If enabled, the input will be refreshed every frame")]
        public bool updateInputEveryFrame = true;

        private void Update()
        {
            if (!updateInputEveryFrame) return;
            InputVR_SendInput();
        }

        /// <summary>
        /// Send input to the fellow monobehaviours on the object. The required method name is GlobalReceived_SetControlInput
        /// </summary>
        public void InputVR_SendInput()
        {
            // If you care about performance, consider using SendMessage as it uses Reflection...
            if (messageReceiver)
                messageReceiver.SendMessage("GlobalReceived_SetControlInput", InputVR_GetInputState());
            else
                SendMessage("GlobalReceived_SetControlInput", InputVR_GetInputState());
        }

        /// <summary>
        /// Get current VR input of the specified attributes
        /// </summary>
        /// <returns>returns true if pressed</returns>
        public bool InputVR_GetInputState()
        {
            if (!Application.isPlaying) return false;
            if (!this.enabled) return false;
            return OVRInput.Get(inputButton, targetDevice);
        }
    }
}