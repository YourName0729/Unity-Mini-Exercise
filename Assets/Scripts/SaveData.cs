using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float[,] positions;
    public float[,] velocities;
    public float[] speeds;
    public float[,] rotations;

    public SaveData(GameObject[] objs)
    {
        positions = new float[objs.Length, 3];
        velocities = new float[objs.Length, 3];
        speeds = new float[objs.Length];
        rotations = new float[objs.Length, 4];
        
        for (int i = 0; i < objs.Length; i++)
        {
            Vector3 pos = objs[i].transform.position;
            Rigidbody rig = objs[i].GetComponent<Rigidbody>();
            Quaternion rot = objs[i].transform.rotation;
            Movement move = objs[i].GetComponent<Movement>();
            float speed = move != null ? move.speed : 0;

            Debug.Log("Obj " + i + " save pos " + pos);
            Debug.Log("Obj " + i + " save speed " + speed);

            positions[i, 0] = pos.x;
            positions[i, 1] = pos.y;
            positions[i, 2] = pos.z;

            speeds[i] = speed;

            if (rig != null)
            {
                velocities[i, 0] = rig.velocity.x;
                velocities[i, 1] = rig.velocity.y;
                velocities[i, 2] = rig.velocity.z;
            }

            rotations[i, 0] = rot.x;
            rotations[i, 1] = rot.y;
            rotations[i, 2] = rot.z;
            rotations[i, 3] = rot.w;
        }
    }

    public void ApplyTo(GameObject[] objs)
    {
        if (objs.Length != speeds.Length)
        {
            Debug.LogError("The save data is not matched:" + objs.Length + " vs " + speeds.Length);
            return;
        }

        for (int i = 0; i < objs.Length; i++)
        {
            Transform trans = objs[i].transform;
            //Quaternion rot = objs[i].transform.rotation;
            Rigidbody rig = objs[i].GetComponent<Rigidbody>();
            Movement move = objs[i].GetComponent<Movement>();

            Debug.Log("Obj " + i + " load pos " + trans.position);
            

            trans.position = new Vector3(positions[i, 0], positions[i, 1], positions[i, 2]);

            if (rig != null)
            {
                rig.velocity = new Vector3(velocities[i, 0], velocities[i, 1], velocities[i, 2]);
            }

            if (move != null)
            {
                move.speed = speeds[i];
                Debug.Log("Obj " + i + " save speed " + move.speed);
            }
            else
            {
                Debug.Log("Obj " + i + " don't has movement");
            }

            trans.rotation = new Quaternion(rotations[i, 0], rotations[i, 1], rotations[i, 2], rotations[i, 3]);
        }
    }
}
