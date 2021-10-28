using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class MenuController : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    CinemachineTrackedDolly dollyCam;

    public GameObject spawnPos;
    public CanvasGroup menuPanel;

    public ParticleSystem particle;

    public AudioSource lightsaberSound;

    private bool readyToMoveCamera = false;
    private bool alphaDone = true;
    private void Start()
    {
        dollyCam = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    private void Update()
    {
        if (readyToMoveCamera)
            dollyCam.m_PathPosition += 0.01f;
        if(!alphaDone)
            menuPanel.alpha += Time.deltaTime * 1.5f;
    }

    public void SpawnParticle()
    {
        lightsaberSound.Play();
        Instantiate(particle, spawnPos.transform.position, Quaternion.identity);
    }

    public IEnumerator LoadMenuItems()
    {
        alphaDone = false;
        yield return new WaitForSeconds(1.5f);
        readyToMoveCamera = true;
        alphaDone = true;
    }

    public void LoadLevelScene()
    {
        SceneManager.LoadScene(1);
    }
}
