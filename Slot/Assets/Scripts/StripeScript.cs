using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StripeScript : MonoBehaviour {

    private bool roztoceno = false;
    private float rychlostStripu = 8f;
	private Transform tr;

	void Start () {
		tr = gameObject.GetComponentInChildren<Transform>();       
    }

	void Update () {
        if (roztoceno) TocimStripe();
    }

    public void TocimStripe()
    {
        Vector3 p = tr.transform.position;
        if (p.y < -27f) p.y += 27f;
        tr.transform.position = p;
        tr.Translate(Vector3.down * Time.deltaTime * rychlostStripu);
    }

    public float ZastavAzaokrouhli()
    {
        Vector3 p = tr.position;
        float a = Mathf.Round(tr.position.y);      
        p.y = a;
        tr.position = p;
        roztoceno = false;
        return tr.position.y;        
    }

    public void RoztocSpripe()
    {
        roztoceno = true;
    }
}
