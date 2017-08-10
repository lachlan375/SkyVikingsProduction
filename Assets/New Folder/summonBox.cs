using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonBox : MonoBehaviour
{
    [Tooltip("box crate extra ")]
    public GameObject objectToApear;
    [Tooltip("this will show when the box is removed")]
   public GameObject endEfeact;
   public ParticleSystem[] Effects;
    [Tooltip("how fast the box will spin")]
    public float SpinSpeed;
    [Tooltip("when the box will apear")]
    public float AppearTime;
    [Tooltip(" box apears")]
    public int[] start;
    [Tooltip("box stops")]
    public int [] end;
    private bool finshed;
    [HideInInspector]
    public bool endGame;
    public AudioClip SoundEfeact;
    public AudioSource source;

    // Use this for initialization
    void OnEnable()
    {
        endEfeact.SetActive(false);
        source.PlayOneShot(SoundEfeact, 0.7F);

    }

    // Update is called once per frame
    void Update()
    {
        #region start  efeacts;

        if (endGame == false)
        {
            objectToApear.SetActive(Effects[start[0]].time >= AppearTime);
            if (Effects[start[0]].isPlaying == true)
            {
                objectToApear.transform.Rotate(0, SpinSpeed, 0);
            }
            
            if(Effects[start[1]].isPlaying == false)
            {
                objectToApear.transform.Rotate(0, 0, 0);
            }
        }
        #endregion
        #region end Efects
        if (endGame == true)
        {
            endEfeact.SetActive(true);
            objectToApear.SetActive(true);
            if (Effects[end[0]].isPlaying == true)
            {
                objectToApear.transform.Rotate(0, SpinSpeed, 0);
            }
            if (Effects[end[1]].isPlaying == false)
            {
                source.PlayOneShot(SoundEfeact, 0.7F);
                Debug.Log("its over");
                Destroy(gameObject);
            }

        }
        #endregion



    }

    public void finshedQest()
    {
        endGame = true;
    }
    public void desorySelf()
    {
        Destroy(gameObject);

    }
}


