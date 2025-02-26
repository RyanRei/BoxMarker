using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using System;
using Unity.VisualScripting;
public class MysteryObject : MonoBehaviour
{
    private float size1 = 0.0f;
    private float size2 = 0.0f;
    private float size3 = 0.0f;
    private float size4 = 0.0f;
    private SkinnedMeshRenderer rendererMain;
    public int[] blendShapeIndices;
    public float duration = 1.0f;
    public float delayBetween = 2f;
    private float blendValue;
    public SoundManager soundManager;
    public AudioClip futuristic;
    public AudioClip transition1;
    public AudioClip transition2;
    public VisualEffect effect;
    public VisualEffect redLightning;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rendererMain = gameObject.GetComponent<SkinnedMeshRenderer>();
        //InvokeRepeating("Name".0.0f,0.1f
        //CancelInvoke
        //MeshRendere.setBlendShapeWeight(0.size++
    }

    // Update is called once per frame

    public void AnimateShapes()
    {
        StartCoroutine(AnimateBlendShapes());
    }
    
     IEnumerator AnimateBlendShapes()
    {
        AudioClip sound = null;
        effect.enabled = true;
        soundManager.PlaySFX(futuristic,0.6f);
        yield return new WaitForSeconds(2f);
        foreach (int index in blendShapeIndices)
        {
            if (index == 0)
            {
                duration = 5f;
                sound = transition2;
            }
            else if (index == 9)
            {
                duration = 2f;
                sound = transition1;
            }
            else
            {
                sound=transition1;
            }
            yield return StartCoroutine(AnimateBlendShape(index, duration,sound));
            yield return new WaitForSeconds(delayBetween);
        }
        effect.enabled = false;
    }
    private IEnumerator AnimateBlendShape(int index, float time,AudioClip sound)
    {
        float elapsedTime = 0f;

        soundManager.PlaySFX(sound);
        while (elapsedTime < time)
        {
            if (index == 0)
            {
                blendValue = Mathf.Lerp(100f, 0f, elapsedTime / time);
            }
            else
            {
                blendValue = Mathf.Lerp(0f, 100f, elapsedTime / time);
            }
            rendererMain.SetBlendShapeWeight(index, blendValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //rendererMain.SetBlendShapeWeight(index, 100f);
    }
    void Update()
    {
        
    }

    public void Animaatebeam(AudioClip audio1)
    {
        StartCoroutine(AnimateOneShape(8, 2f, audio1));
    }
    public IEnumerator AnimateOneShape(int index,float duration,AudioClip sound)
    {
        StartCoroutine(AnimateBlendShape(index, duration, transition1));
        yield return new WaitForSeconds(2f);
        soundManager.PlaySFX(sound,1f);
        redLightning.enabled = true;
        yield return new WaitForSeconds(14f);
        redLightning.enabled = false;   

    }
}
