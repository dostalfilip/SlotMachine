using UnityEngine;
using System.Collections;

public class BonusPivo : MonoBehaviour {

    public Sprite[] polePiv;

    private int pocetbonusu=-1;
    private SpriteRenderer m_SpriteRenderer;
    private GameManager GManager;

    void Awake() {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        GManager = GameObject.FindObjectOfType<GameManager>();
        NextBeer();
    }

    public void NextBeer()
    {
        pocetbonusu++;
        if (pocetbonusu ==7)
        {
            pocetbonusu = 0;
            GManager.bodyCelkem *= 10;
        }
        m_SpriteRenderer.sprite = polePiv[pocetbonusu];
    }
}
