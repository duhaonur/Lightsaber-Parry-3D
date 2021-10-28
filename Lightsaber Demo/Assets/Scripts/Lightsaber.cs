using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
public class Lightsaber : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public GameObject otherSaber;

    public Simulate simulate;
    public TextController _textController;
    public SoundController soundController;
    

    private bool noDrag = false;

    [HideInInspector] public ParticleSystem particle;
    [HideInInspector] public bool enableCollisionEffects;

    private void Update()
    {
        if (simulate.isSimulatePressed)
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, otherSaber.transform.position.z), 3f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( enableCollisionEffects)
        {
            ContactPoint contact = collision.contacts[0];

            Vector3 pos = contact.point;
            soundController.PlayAudio();
            Instantiate(particle, pos, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            noDrag = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sword")
        {
            noDrag = false;
        }
    }

    public void RotateSword()
    {
        _textController.HideText();
        transform.localRotation = Quaternion.Euler(0, 0, slider.value);
    }
    public void Notification()
    {
        if(noDrag)
        {
            _textController.LightsabersCollidingText();
            _textController.DisplayText();
        }
        else
        {
            _textController.LightsabersNotCollidingText();
            _textController.DisplayText();
        }
    }

    #region Unity_Editor
#if UNITY_EDITOR
    [CustomEditor(typeof(Lightsaber))]
    public class LightsaberEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector(); // for other non-HideInInspector fields

            Lightsaber lightSaber = (Lightsaber)target;

            // draw checkbox for the bool
            lightSaber.enableCollisionEffects = EditorGUILayout.Toggle("Enable Collision Effect", lightSaber.enableCollisionEffects);
            if (lightSaber.enableCollisionEffects) // if bool is true, show other fields
            {
                lightSaber.particle = EditorGUILayout.ObjectField("Particle Effect", lightSaber.particle, typeof(ParticleSystem), false) as ParticleSystem;
            }
        }
    }
#endif
    #endregion
}
