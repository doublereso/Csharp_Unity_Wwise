/// Script by Petr Yakyamsev

using UnityEngine;

public class ColliderSwitchWwise : MonoBehaviour
{

    public string switchGroupName;
    public string switchStateNameInside;
    public int switchID;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon")
        {
            AkSoundEngine.SetSwitch(switchGroupName, switchStateNameInside, other.gameObject);
        }
        
    }
}
