/// Script by Petr Yakyamsev

using UnityEngine;

public class OcclusionWwise : MonoBehaviour
{
    public GameObject gameObjectListener, gameObjectPlayer;
    public float wwiseOcclusion;
    private float maxWallThickness = 20.0f;
    private float wallThickness, distToPlayer, maxAtt;
    private Vector3 originPoint, playerPoint, targetDirection1, targetDirection2, wallPointIn, wallPointOut;
    private RaycastHit hitInfo1, hitInfo2;
    private int layerMask = 1 << 23;
    private bool insideRoom;

    void Start()
    {
        wallPointIn = Vector3.zero;
        wallPointOut = Vector3.zero;
        InvokeRepeating("OcclusionCalc", 0.1f, 0.1f);
    }

    void OcclusionCalc ()
    {

        maxAtt = AkSoundEngine.GetMaxRadius(gameObject); //getting attenuation data from sound source
        originPoint = transform.position; //coordinates of soundsource
        playerPoint = gameObjectPlayer.transform.position; //coordinates of Player
       

        //we are gonna control occlusion only based on the wall thickness (distance between point of raycast hitting 1st wall and point of raycast goes out of the wall to hit the Player)

        if (distToPlayer <= maxAtt) //raycasting starts once Player is within the attenuation radius
        {
            targetDirection1 = playerPoint - originPoint;
            distToPlayer = Vector3.Distance(playerPoint, originPoint);
            if (Physics.Raycast(originPoint, targetDirection1, out hitInfo1, distToPlayer, layerMask))
            {
                wallPointIn = hitInfo1.point;

                targetDirection2 = Vector3.zero - targetDirection1;
                if (Physics.Raycast(playerPoint, targetDirection2, out hitInfo2, distToPlayer, layerMask))
                {
                    wallPointOut = hitInfo2.point;
                    if (Physics.Raycast(playerPoint, Vector3.down, 2.0f, layerMask))
                    {
                        insideRoom = true;
                    }
                    else { insideRoom = false; }
                }
                else { wallPointOut = Vector3.zero; }
            }

            else { wallPointIn = Vector3.zero; }

            if (wallPointIn == Vector3.zero)
            {
                wwiseOcclusion = 0.0f;
            }

            else
            {
                wallThickness = Vector3.Distance(wallPointOut, wallPointIn);
                wwiseOcclusion = wallThickness / maxWallThickness;
                if (insideRoom == true)
                {
                    wwiseOcclusion += 1.0f;
                }

                if (wwiseOcclusion > 1.0f)
                {
                    wwiseOcclusion = 1.0f;
                }
            }

            AkSoundEngine.SetObjectObstructionAndOcclusion(gameObject, gameObjectListener, 0.0f, wwiseOcclusion);
        }
    }
}
