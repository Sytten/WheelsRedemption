public class FinishPlatformBehavior : Behavior {

    public override void Execute(State state) {
        state.HeroWin();
    }
}