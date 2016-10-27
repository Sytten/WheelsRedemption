public class LavaBehavior : Behavior {

    public override void Execute(State state) {
        state.KillHero();
    }
}