using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class Simulate : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    CinemachineTrackedDolly dollyCam;

    public EndGame endGame;

    public bool  isSimulatePressed;
    public float pathPosition = 0.0f;
    public float pathMaxLength = 0.0f;
    public float pathMinLength = 0.0f;
    public float speed;

    private void Start()
    {
        dollyCam = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
        pathMaxLength = dollyCam.m_Path.MaxPos;
        pathMinLength = dollyCam.m_Path.MinPos;
    }
    public IEnumerator SimulateButton()
    {
        isSimulatePressed = true;
        yield return new WaitForSeconds(2f);
        isSimulatePressed = false;
    }
    public void SimulateButtonPressed()
    {
        StopCoroutine(SimulateButton());
        StartCoroutine(SimulateButton());
        StartCoroutine(MoveCameraToDestination());
    }
    private IEnumerator MoveCameraToDestination()
    {

        for (float pathPosition = pathMinLength; pathPosition < pathMaxLength;)
        {
            pathPosition += speed;
            yield return new WaitForSeconds(0.1f);
            dollyCam.m_PathPosition = pathPosition;
        }
        endGame.EndTheGame();
    }

}
