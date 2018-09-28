using UnityEngine;

public class EffectsToggleControl : UIOptionEffect {

    [SerializeField]
    StartGamePref startGamePref;

    public override void ToggleActive()
    {
        base.ToggleActive();
        startGamePref.SetPrefs();
    }

}
