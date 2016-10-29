using UnityEngine;

class InputEventTranslator {

    public static InputEvent toEvent(Touch input) {
        return new InputEvent().WithPosition(input.position)
                               .WithPhase(input.phase);
    }
}

