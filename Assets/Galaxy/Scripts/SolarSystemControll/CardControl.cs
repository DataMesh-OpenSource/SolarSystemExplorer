using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardControl : MonoBehaviour {

    public static CardControl Instance;

    public GameObject controlPanel;
    public Slider sliderRotate;
    public Slider sliderScale;

    [Serializable]
    public struct UICard
    {
        public Transform planetUI;
        public MeshRenderer description;
        public string name;
        public bool followPlanet;
    }

    public List<UICard> cards;

    private string currentPlanetName = null;

	// Use this for initialization
	void Awake () {
        Instance = this;

        //controlPanel.SetActive(false);
	}
	// Update is called once per frame
	void Update () {

        for (int i = 0;i < cards.Count;i ++)
        {
            UICard card = cards[i];
            if (card.followPlanet)
            {
                card.planetUI.position = SolarSystem.Instance.GetPlanetWorldPosition(card.name);
            }

        }
    }

    public void OnGazePlanet(string name)
    {
        currentPlanetName = name;
        SolarSystem.Instance.SetFocusedPlanet(name);
    }
}
