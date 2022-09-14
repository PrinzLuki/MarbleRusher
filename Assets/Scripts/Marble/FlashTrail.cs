using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashTrail : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    public float meshRefreshRate = 0.1f;

    float activeTime = 1f;

    List<GameObject> trialObjs = new();

    MarbleMovement player;
    public float speedMultiplier;

    void Start()
    {
        player = GetComponent<MarbleMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(StartTrail());
        }
    }

    IEnumerator StartTrail()
    {

        while (activeTime > 0)
        {
            activeTime -= meshRefreshRate;

            GameObject clone = new("Trail");

            clone.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            clone.transform.position = this.transform.position;
            MeshFilter filter = clone.AddComponent<MeshFilter>();
            filter.mesh = mesh;

            transform.Translate((player.speed * speedMultiplier) * Time.deltaTime * player.FlashDirection);
            MeshRenderer renderer = clone.AddComponent<MeshRenderer>();
            renderer.sharedMaterial = material;
            trialObjs.Add(clone);
            yield return new WaitForSeconds(0.01f);
        }


        for (int i = 0; i < trialObjs.Count; i++)
        {
            Destroy(trialObjs[i]);
            yield return new WaitForSeconds(0.01f);
        }

        activeTime = 1;

    }
}
