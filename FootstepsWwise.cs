/// This is modified script of DarkTreeDevelopment (2019) DarkTree FPS v1.1
/// Now it is hooked up to Wwise instead of Unity's core audio system
/// Modification done by Petr Yakyamsev

using UnityEngine;

namespace DarkTreeFPS
{
    public class FootstepsWwise : MonoBehaviour
    {
        GetCollisionTag collisionTag;
        GetCollisionTag collisionTagBuffer;
        public string footstepsSFX;

        private void Start()
        {
            collisionTag = GameObject.Find("Player").GetComponent<GetCollisionTag>();
        }

        public void PlayFootstep()
        {
            switch (collisionTag.contactTag)
            {
                case "Dirt":
                    AkSoundEngine.PostEvent(footstepsSFX, gameObject);
                    break;
                case "Wood":
                    AkSoundEngine.SetSwitch("footsteps", "wood", gameObject);
                    AkSoundEngine.PostEvent(footstepsSFX, gameObject);
                    collisionTagBuffer = collisionTag;
                    break;
                case "Concrete":
                    AkSoundEngine.SetSwitch("footsteps", "concrete", gameObject);
                    AkSoundEngine.PostEvent(footstepsSFX, gameObject);
                    collisionTagBuffer = collisionTag;
                    break;
                case "Metal":
                    AkSoundEngine.SetSwitch("footsteps", "metal", gameObject);
                    AkSoundEngine.PostEvent(footstepsSFX, gameObject);
                    collisionTagBuffer = collisionTag;
                    break;
                case "Water":
                    AkSoundEngine.SetSwitch("footsteps", "water", gameObject);
                    AkSoundEngine.PostEvent(footstepsSFX, gameObject);
                    collisionTagBuffer = collisionTag;
                    break;
                case "Sand":
                    AkSoundEngine.SetSwitch("footsteps", "sand", gameObject);
                    AkSoundEngine.PostEvent(footstepsSFX, gameObject);
                    collisionTagBuffer = collisionTag;
                    break;
                default:
                    AkSoundEngine.SetSwitch("footsteps", collisionTagBuffer.contactTag, gameObject);
                    AkSoundEngine.PostEvent(footstepsSFX, gameObject);
                    break;
            }
        }
    }
}
