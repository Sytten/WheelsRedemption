public class LavaBehavior : Behavior {

    public override void Execute(OnPlatformState state) {
        Execute((State) state);
    }

    public override void Execute(InAirState state) {
        Execute((State) state);
    }

    public override void Execute(State state) {
        state.KillHero();
    }
}