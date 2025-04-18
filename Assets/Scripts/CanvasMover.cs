using UnityEngine;
using System.Collections;

public class CanvasMover : MonoBehaviour
{
    public GameObject uiToMove1;
    public GameObject uiToMove2;
    public GameObject uiToDeactivate;

    public float movementDistance = 1.25f;
    public float moveDuration = 0.5f;

    private bool isMoved = false;
    private Vector3 ui1StartPos, ui2StartPos;

    void Start()
    {
        if (uiToMove1 != null) ui1StartPos = uiToMove1.transform.position;
        if (uiToMove2 != null) ui2StartPos = uiToMove2.transform.position;
    }

    public void HandleCanvasMoveAndToggle()
    {
        if (!isMoved)
        {
            uiToMove1.SetActive(true);
            uiToMove2.SetActive(true);
            if (uiToDeactivate != null) uiToDeactivate.SetActive(false);

            // Move out in opposite directions
            StartCoroutine(MoveUI(uiToMove1, ui1StartPos, ui1StartPos + new Vector3(movementDistance, 0, 0), false));
            StartCoroutine(MoveUI(uiToMove2, ui2StartPos, ui2StartPos + new Vector3(-movementDistance, 0, 0), false));
        }
        else
        {
            // Move back to original positions
            StartCoroutine(MoveUI(uiToMove1, uiToMove1.transform.position, ui1StartPos, true));
            StartCoroutine(MoveUI(uiToMove2, uiToMove2.transform.position, ui2StartPos, true));

            StartCoroutine(ActivateAfterDelay(moveDuration, uiToDeactivate));
        }

        isMoved = !isMoved;
    }

    IEnumerator MoveUI(GameObject uiObj, Vector3 fromPos, Vector3 toPos, bool deactivateAtEnd)
    {
        float elapsed = 0f;
        Transform uiTransform = uiObj.transform;

        while (elapsed < moveDuration)
        {
            uiTransform.position = Vector3.Lerp(fromPos, toPos, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        uiTransform.position = toPos;

        if (deactivateAtEnd)
        {
            uiObj.SetActive(false);
        }
    }

    IEnumerator ActivateAfterDelay(float delay, GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        if (obj != null)
            obj.SetActive(true);
    }
}
