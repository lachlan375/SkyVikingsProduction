using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    public bool oarsEngaged;
    public int numStrokes = 0;

    Rigidbody rb;

    public float thrust = 100;
    public float passiveRatio = 0.5f;

    public float rotationClamp;

    [Tooltip("For more natural turning, force will be applied this distance forward from the center of mass.")]
    public float turnForceOffset;

    public bool tiltFuction;
    public float tilt;

    public Quaternion originalRotation;
    public Quaternion toTransform;

    [Tooltip("Rotation time for tilting")]
    public float time;

    public Animator rowerAnimPort;
    public Animator rowerAnimSB;
    public List<Transform> respawnPoints;
    public float timeCount;  //Timer initiated when keypress taken off;

    bool respawning = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    IEnumerator Respawn()
    {
        respawning = true;
        yield return new WaitForSeconds(3);
        Transform close = respawnPoints[0];
        foreach (var point in respawnPoints)
        {
            if (Vector3.Distance(close.position, transform.position) > Vector3.Distance(point.position, transform.position))
            {
                close = point;
            }
        }
        transform.position = close.position;
        transform.rotation = close.rotation;
        respawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (!rb.SweepTest(Vector3.down, out hit) && !respawning)
        {
            StartCoroutine(Respawn());
        }

        // turn the boat based on the horizontal axis input
        UpdateTurn();

        // move the boat forwards and backward based on vertical axis
        UpdateRowing();
    }

    public float rowingSpeed = 0;

    void UpdateRowing()
    {
        float force = 0;
        float acceleration = Input.GetAxis("Vertical");

        bool isRowing = false;
        bool isReversing = false;



        // if we press back, accelerate backwards
        if (acceleration < 0)
        {
            force -= 0.5f;
            isRowing = true;
            isReversing = true;
        }

        // if we press forwards, accelerate forwards
        if (acceleration > 0)
        {
            force = 1;
            isRowing = true;
            isReversing = false;
        }

        // reset stroke counter if we stop rowing, or
        // cap at 8 strokes (4 each side)
        if (acceleration == 0)
        {
            //StartCoroutine(StrokeDecay)
            //In Update if (StrokeDecay is active), break/stop StrokeDecay if Acceleration && if numStrokes <= 0 break/stop StrokeDecay
            //In Coroutine - yield return new WaitForSeconds(1) numStrokes--;
            numStrokes = 0;
        }

        if (numStrokes > 8)
            numStrokes = 8;

        // only give us half forwards power if the oars arent engaged
        // we need this to stop us grinding to a halt due to high drag
        float power = passiveRatio;
        if (oarsEngaged)
        {
            power = 1.0f;
            // give us double power for the first stroke
            if (numStrokes < 4)
            {
                power = 2.0f;
            }
        }

        rb.AddForce(numStrokes * power * force * thrust * transform.forward);

        rowingSpeed = 50 * rb.velocity.magnitude;

        // update rowing animation

        rowerAnimPort.SetBool("isRowing", isRowing);
        rowerAnimPort.SetFloat("currentSpeed", rowingSpeed);
        rowerAnimPort.SetBool("isReversing", isReversing);

        rowerAnimSB.SetBool("isRowing", isRowing);
        rowerAnimSB.SetFloat("currentSpeed", rowingSpeed);
        rowerAnimSB.SetBool("isReversing", isReversing);
    }

    void UpdateTurn()
    {
        originalRotation = transform.rotation;

        float rotate = Input.GetAxis("Horizontal");

        rotate = Mathf.Clamp(rotate, -rotationClamp, rotationClamp);

        // work out the angle we should at due to our turning
        // TODO - make this stronger with forwards velocity
        float desiredZAngle = rotate * -25.0f;

        // and lerp towards it.
        float toTransformY = originalRotation.eulerAngles.y;
        toTransform = Quaternion.Euler(0.0f, toTransformY, desiredZAngle);

        rb.rotation = Quaternion.Slerp(originalRotation, toTransform, Time.deltaTime * time);

        originalRotation = rb.rotation;

        if (rotate != 0)
        {
            //Rotate object using add Force at Pos
            Vector3 forceAddPos = transform.position + rb.centerOfMass + (transform.forward * turnForceOffset);
            rb.AddForceAtPosition(transform.right * /*rotationVarArray[currentSpeedInt]*/ 200 * rotate, forceAddPos);
        }
    }

}
