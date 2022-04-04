using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    RogueLikeGenerator gen;
    public Transform toGenerate;

    Transform curRoom;
    Transform roomEnd;
    bool gotTriggered;

    private void Start()
    {
        gen = GameObject.FindObjectOfType<RogueLikeGenerator>();
        curRoom = transform.parent;
        roomEnd = curRoom.GetChild(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MC" && !gotTriggered)
        {
            Transform newRoom = gen.GenerateRoom(toGenerate, roomEnd);

            gen.SetupRoutes(newRoom);
            gen.SetupRoom(newRoom);

            gotTriggered = true;

            Destroy(this.gameObject);
        }
    }
}
