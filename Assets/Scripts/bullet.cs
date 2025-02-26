using NUnit.Framework.Internal;
using System;
using UnityEngine;
using Unity.Collections;

public class bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float life = 3f;
    public GameObject parentObjSpawn;
    public MaskAnimator maskAnim;
    //public GameObject mainBox;
    private Material Boxmaterial;
    private float currentValue = 0.514f;
    private float speed = 0.01f;
    bool activated = false;
    public SoundManager soundManager;
    public AudioClip random;
    public AudioClip pressA;
    public AudioClip pressB;
    public MysteryObject mysteryobject;
    public AudioClip audio1;

    private float pressScale = 0.8f;
    private Vector3 originalScale;

    private bool roboActive=false;
    public int tap = 1;

    private void Awake()
    {
        // Destroy(gameObject,life);
        //Boxmaterial = mainBox.GetComponent<MeshRenderer>().materials[1];
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Perofrming Collision!!!!!!!");
        if(collision.gameObject.CompareTag("Transforming Box"))
        {
            Debug.Log("Perofrming PERFECTLY!");
            gameObject.transform.SetParent(parentObjSpawn.transform);
            gameObject.transform.localPosition = Vector3.zero;

        }
        //Destroy(gameObject);
        //Destroy(collision.gameObject);
    }


    public void updateEmissionMap()
    {
        activated = true;
    }
    public void parenter()
    {
          
    }
    void Start()
    {
        Debug.Log(tap);
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            currentValue = Mathf.MoveTowards(currentValue, 1f, speed * Time.deltaTime);
            Boxmaterial.SetFloat("_fill", currentValue);
            Debug.Log(currentValue);
        }

        if (!roboActive)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        PressButton();
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        ReleaseButton();
                        
                    }
                }
            }
        }
    }
    

    public void PressButton()
    {
        soundManager.PlaySFX(pressA);
        transform.localScale = originalScale * pressScale;
        
        //if (buttonRenderer != null) buttonRenderer.material.color = pressedColor;
    }

    public void ReleaseButton()
    {
        
        if (this.tap == 1)
        {
            transform.localScale = originalScale;
            maskAnim.maskAnimate();
            this.tap+=1;

        }
        else if (this.tap == 2)
        {
            transform.localScale = originalScale;




            soundManager.PlaySFX(pressB);

            mysteryobject.AnimateShapes();
            //roboActive = true;
            this.tap+=1;
        }
        else if (this.tap >= 3)
        {
            transform.localScale = originalScale;
            mysteryobject.Animaatebeam(audio1);
        }
   
    }


  
}
