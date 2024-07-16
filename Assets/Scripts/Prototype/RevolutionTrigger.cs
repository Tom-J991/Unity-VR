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

    [Range(0, 100), Tooltip("Only really matters for the full revolution.")] 
    public int randomChanceSin = 30;
    [Range(0, 100), Tooltip("Only really matters for the full revolution.")]
    public int randomChanceMiracle = 50;

    /// <summary>
    /// Private recursive function to get the region component from a hierarchy of objects.
    /// </summary>
    /// <param name="obj">The first object to check.</param>
    /// <param name="depth">The depth of recursion, should be set to 0.</param>
    public static Region GetRegionFromParent(Transform obj, int depth = 0) // TODO: Move to a utility class.
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

                if (region.plagued) // Don't increase sin for a plagued region.
                {
                    region.sinTier -= 1;
                    foreach(Region neighbour in region.neighbors)
                    {
                        neighbour.sinTier -= 1;
                    }
                    region.plagued = false; // Reset plague flag.
                    break;
                }

                    if (region.blessed) // Don't increase sin for a plagued region.
                    {
                        region.miracleTier -= 1;
                        foreach (Region neighbour in region.neighbors)
                        {
                            neighbour.miracleTier -= 1;
                        }
                        region.blessed = false; // Reset plague flag.
                        break;
                    }

                bool shouldSin = region.sinTier > 0; // Is sinning.
                bool shouldMiracle = region.miracleTier > 0; // Is believing.

                // If region isn't already believing or sinning, have a random chance for it to do start doing either.
                if (region.miracleTier <= 0 && region.sinTier <= 0)
                {
                    int chance = Random.Range(0, 100);
                    if (chance <= randomChanceSin)
                    {
                        shouldSin = true;
                    }
                    else if(chance <= randomChanceMiracle)
                    {
                        shouldMiracle = true;
                    }
                }

                if (shouldSin)
                {
                    region.Sin(); // Region should increase sin tier on a full revolution.
                }
                else if (shouldMiracle)
                {
                    region.Miracle(); // Region should increase belief tier on a full revolution.
                }
            } break;
        }
    }
}
