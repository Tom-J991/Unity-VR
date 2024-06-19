using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Trigger script for each revolution of the planet.
/// </summary>
public class RevolutionTrigger : MonoBehaviour
{
    public enum TriggerType
    {
        QuarterWay,
        HalfWay,
        FullRevolution
    }
    public TriggerType type = TriggerType.QuarterWay;

    /// <summary>
    /// Private recursive function to get the region component from a hierarchy of objects.
    /// </summary>
    /// <param name="obj">The first object to check.</param>
    /// <param name="depth">The depth of recursion, should be set to 0.</param>
    private Region GetRegionFromParent(Transform obj, int depth = 0)
    {
        if (depth > 3) // Stop if recursion is too deep. Avoids infinite loop.
            return null;

        Region region = obj.GetComponent<Region>();
        if (region == null) // No region found, repeat with parent.
        {
            depth++;
            return GetRegionFromParent(obj.parent, depth);
        }

        return region;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Handle regions per revolution.
        Region region = GetRegionFromParent(other.transform); // TODO: Probably shouldn't do this function on objects that definitely aren't a region.
        if (region == null) // Probably not a region.
            return;

        switch (type)
        {
            case TriggerType.QuarterWay:
            {
                Debug.Log("Quarter Way!");
            } break;
            case TriggerType.HalfWay:
            {
                Debug.Log("Half Way!");
            } break;
            case TriggerType.FullRevolution:
            {
                Debug.Log("Revolution!");
                region.Sin(); // Region should increase sin tier on a full revolution.
            } break;
        }
    }
}
