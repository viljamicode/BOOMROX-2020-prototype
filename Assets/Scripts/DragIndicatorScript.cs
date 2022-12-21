using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Huge thanks to Danny Bergs on YouTube for the initial tutorial and @derHugo from stackoverflow for helping it better suit my needs! -vr

public class DragIndicatorScript : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform lineAnchor;
    [SerializeField] private Material lineMaterial;
    [SerializeField] private AnimationCurve animCurve;

    

    private void Awake()
    {
        if (!TryGetComponent<LineRenderer>(out lineRenderer))
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.widthCurve = animCurve;
        lineRenderer.numCapVertices = 10;
        lineRenderer.material = lineMaterial;
        /* lineRenderer.startColor = Color.magenta;
        lineRenderer.endColor = Color.cyan; */
        lineRenderer.SetPosition(0, lineAnchor.position);
        lineRenderer.enabled = false;
    }
    void Update()
    {
        lineRenderer.SetPosition(0, lineAnchor.position);
    }

    public void HideIndicator()
    {
        lineRenderer.enabled = false;
    }

    public void SetIndicator(Vector3 input)
    {
        lineRenderer.SetPosition(1, lineAnchor.position + input);
        lineRenderer.enabled = true;
    }
}