using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
   
    public Text bodyCelkemText;
    private int BodyCelkem = 20;

    public int bodyCelkem
    {
        get { return BodyCelkem; }
        set {
            BodyCelkem = value;
            bodyCelkemText.text = bodyCelkem.ToString();
            }
    }

    private PointScript[] pointScripts;
    private StripeScript[] stripesArray;
    private bool roztoceno = false;
    private BonusPivo bonusPivo;
    private float polohaStripu1;
    private float polohaStripu2;
    private float polohaStripu3;

    void Awake () {
        pointScripts = GameObject.FindObjectsOfType<PointScript>();
        bonusPivo = GameObject.FindObjectOfType<BonusPivo>();
        bodyCelkemText.text = bodyCelkem.ToString();
        stripesArray = GameObject.FindObjectsOfType<StripeScript>();
    }

    public void RoztocStripy()
    {
        if (!roztoceno)
        {
            bodyCelkem--;
            roztoceno = true;
            foreach (PointScript item in pointScripts)
            {
                item.State = PointScript.PointState.Off;
            }
            foreach (StripeScript stripe in stripesArray)
            {
                stripe.RoztocSpripe();
            }
            StartCoroutine(ZastavStripy());   
        }        
    }
    IEnumerator ZastavStripy()
    {
        yield return new WaitForSeconds(Random.value * 2);
       polohaStripu1= stripesArray[2].ZastavAzaokrouhli();
        yield return new WaitForSeconds(Random.value * 2);
       polohaStripu2= stripesArray[1].ZastavAzaokrouhli();
        yield return new WaitForSeconds(Random.value * 2);
       polohaStripu3 = stripesArray[0].ZastavAzaokrouhli();
        yield return new WaitForSeconds(Random.value * 4);
        ZjistiCoPadlo();
    }

    public void ZjistiCoPadlo()
    {      
        roztoceno = false;
        float stripe = CoPadloNaStripu(polohaStripu1);
        float stripe2 = CoPadloNaStripu(polohaStripu2);
        float stripe3 = CoPadloNaStripu(polohaStripu3);

       Debug.Log(stripe + " " + stripe2 + " " + stripe3);

        if (stripe==stripe2 && stripe2 ==stripe3)
        {
            bodyCelkem += (int)stripe;
            foreach (PointScript item in pointScripts)
            {
                if (item.gameObject.name == stripe.ToString())
                {
                    item.State = PointScript.PointState.Blinking;
                }
            }
        }
        else if (stripe == 100 || stripe2 == 100|| stripe3==100)
        {
            bonusPivo.NextBeer();
            foreach (PointScript item in pointScripts)
            {
                if (item.gameObject.name.ToString() == "100")
                {
                    item.State = PointScript.PointState.Blinking;
                }
            }          
        }
        else
        {
            foreach (PointScript item in pointScripts)
            {
                    item.State = PointScript.PointState.Blinking;
            }
        }

    }

   public float CoPadloNaStripu(float poziceStripu)
    {
        int body = 0;
        
        if (poziceStripu == -2 || poziceStripu == -10 || poziceStripu == -9 || poziceStripu == -8 ||
            poziceStripu == -17 || poziceStripu == -25 || poziceStripu == -24 || poziceStripu == -23)
        {
            body = 10;
        }
        else if (poziceStripu == -3 || poziceStripu == -6 || poziceStripu == -7 || poziceStripu == -18 || poziceStripu == -21 || poziceStripu == -22)
        {
            body = 20;
        }
        else if (poziceStripu == 0 || poziceStripu == -5 || poziceStripu == -12 || poziceStripu == -15 || poziceStripu == -20 || poziceStripu == -27)
        {
            body = 30;
        }
        else if (poziceStripu == -4 || poziceStripu == -14 || poziceStripu == -19)
        {
            body = 40;
        }
        else if (poziceStripu == -1 || poziceStripu == -13 || poziceStripu == -16)
        {
            body = 50;
        }
        else body = 100;

        return body;
    }
}
