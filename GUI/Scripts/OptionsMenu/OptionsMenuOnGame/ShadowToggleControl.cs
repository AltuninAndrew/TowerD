using UnityEngine;

public class ShadowToggleControl :UIOptionShadow {

    [SerializeField]
    StartGamePref startGamePref;

    public override void ToggleActive()
    {
        base.ToggleActive();
        startGamePref.SetPrefs();
    }

}
