using System.Collections.Generic;
using UnityEngine;

public class InputStorage : MonoBehaviour
{
    private List<Vector3> OldDirectionList = new List<Vector3>();
    private List<Vector3> DirectionList = new List<Vector3>();
    [SerializeField] private RSE_Player playerEvent;

    private void OnEnable()
    {
        playerEvent.ObjectifDone += NewTurn;
    }

    private void OnDisable()
    {
        playerEvent.ObjectifDone -= NewTurn;
    }

    public void AddDirection(Vector3 dir)
    {
        DirectionList.Add(dir);
    }

    private void NewTurn()
    {
        List<Vector3> mergedList = new List<Vector3>();

        for (int i = 0; i < DirectionList.Count; i++)
        {
            Vector3 oldDir = i < OldDirectionList.Count ? OldDirectionList[i] : Vector3.zero;
            Vector3 newDir = DirectionList[i];

            float x = (oldDir.x != 0 || newDir.x != 0) ? Mathf.Max(Mathf.Abs(oldDir.x), Mathf.Abs(newDir.x)) * Mathf.Sign(oldDir.x + newDir.x) : 0;
            float y = (oldDir.y != 0 || newDir.y != 0) ? Mathf.Max(Mathf.Abs(oldDir.y), Mathf.Abs(newDir.y)) * Mathf.Sign(oldDir.y + newDir.y) : 0;
            float z = (oldDir.z != 0 || newDir.z != 0) ? Mathf.Max(Mathf.Abs(oldDir.z), Mathf.Abs(newDir.z)) * Mathf.Sign(oldDir.z + newDir.z) : 0;

            mergedList.Add(new Vector3(x, y, z));
        }

        if (OldDirectionList.Count > DirectionList.Count)
        {
            for (int i = DirectionList.Count; i < OldDirectionList.Count; i++)
            {
                mergedList.Add(OldDirectionList[i]);
            }
        }

        if (DirectionList.Count > OldDirectionList.Count)
        {
            for (int i = OldDirectionList.Count; i < DirectionList.Count; i++)
            {
                mergedList.Add(DirectionList[i]);
            }
        }

        OldDirectionList = mergedList;
        DirectionList.Clear();
    }
}
