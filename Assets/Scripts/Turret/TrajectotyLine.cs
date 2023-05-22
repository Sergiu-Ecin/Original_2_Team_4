using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectotyLine : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] int lineSegments = 60;
    [SerializeField] float timeOfTheFlight = 5;

    public void ShowTrajectoryLine(Vector3 startpoint, Vector3 startvelocity)
    {
        float timeStep = timeOfTheFlight / lineSegments;

        Vector3[] lineRendererPoints = CalculateTrajectoryLine(startpoint, startvelocity, timeStep);

        lineRenderer.positionCount = lineSegments;
        lineRenderer.SetPositions(lineRendererPoints);
    }

    private Vector3[] CalculateTrajectoryLine(Vector3 startpoint, Vector3 startVelocity, float timeStep)
    {
        Vector3[] lineRendererPoints = new Vector3[lineSegments];
        lineRendererPoints[0] = startpoint;

        for (int i = 1; i < lineSegments; i++)
        {
            float timeOffset = timeStep * i;

            Vector3 progressBeforeGravity = startVelocity * timeOffset;
            Vector3 gravityOffset = Vector3.up * 0.5f * Physics.gravity.y * timeOffset * timeOffset;
            Vector3 newPosition = startpoint + progressBeforeGravity - gravityOffset;
            lineRendererPoints[i] = newPosition;
        }
        return lineRendererPoints;
    }
}
