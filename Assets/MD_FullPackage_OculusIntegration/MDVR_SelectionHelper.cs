using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace MD_Plugin
{
    /// <summary>
    /// Selection VR Helper - additional component for extended VR support
    /// </summary>
    [AddComponentMenu(MD_Debug.ORGANISATION + MD_Debug.PACKAGENAME + "VR Input/Selection VR Helper")]
    public class MDVR_SelectionHelper : MonoBehaviour
    {
        [System.Serializable]
        public struct EventElement
        {
            [Tooltip("Required object name to hit")]
            public string requiredName;
            [Tooltip("Specific event if the object is successfully hit")]
            public UnityEvent targetEvent;
        }
        public EventElement[] eventElements;
        [Space]
        [Tooltip("Use line renderer as a visual. Leave it empty if nto needed...")]
        public LineRenderer targetLineRenderer;

        /// <summary>
        /// Specific method for the required listener from MDInputVR components [If pressed, the ray will be created along the object's forward direction]
        /// </summary>
        public void GlobalReceived_SetControlInput(bool pressed)
        {
            if (targetLineRenderer) targetLineRenderer.enabled = true;
            if (targetLineRenderer) targetLineRenderer.SetPosition(0, transform.position);

           Ray r = new Ray(transform.position, transform.forward);
            if (!Physics.Raycast(r, out RaycastHit h))
            {
                if (targetLineRenderer) targetLineRenderer.enabled = false;
                return;
            }
            if (!h.collider)
            {
                if (targetLineRenderer) targetLineRenderer.enabled = false;
                return;
            }
            if (targetLineRenderer) targetLineRenderer.SetPosition(1, h.point);

            if (!pressed) return;

            foreach (EventElement e in eventElements)
            {
                if (e.requiredName == h.collider.name) e.targetEvent?.Invoke();
            }
        }
    }
}