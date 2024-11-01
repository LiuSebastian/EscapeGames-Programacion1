using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{

        public int teleportNumber;
        public TeleportSequenceController sequenceController;
        public Transform teleportDestination;

    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                sequenceController.ActivateTeleport(teleportNumber);
                other.transform.position = teleportDestination.position;

        }
        }
    }

