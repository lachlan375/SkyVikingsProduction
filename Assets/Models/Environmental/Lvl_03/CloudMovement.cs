using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float distance = 20;
    public float speed = 3;
    Vector3 basePos;

    void Start()
    {
        basePos = transform.position;
        Test();
    }

    void Test()
    {
        var pos = Random.insideUnitCircle * distance;
        var posTranslated = new Vector3(basePos.x + pos.x, basePos.y, basePos.z + pos.y);
        StartCoroutine(MoveTo(posTranslated));
    }

    IEnumerator MoveTo(Vector3 pos)
    {
        float i = 0;
        while (i < 10 /*time*/)
        {
            transform.position = Vector3.Lerp(basePos, pos, i / 15);
            yield return new WaitForSeconds(Time.deltaTime);
            i += Time.deltaTime;
        }
        yield return new WaitForSeconds(1);
        while (i > 0)
        {
            {
                transform.position = Vector3.Lerp(basePos, pos, i / 15);
                yield return new WaitForSeconds(Time.deltaTime);
                i -= Time.deltaTime;
            }
        }
        yield return new WaitForSeconds(1);
        Test();
    }
}
