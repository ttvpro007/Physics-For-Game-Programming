public static class ForceEvaluator
{
    public static float Evaluate(float maxForce, float lerpValue)
    {
        // parabola curve
        // with y = 1 at x = 0.5 
        // and  y = 0 at x = 0   or   1
        float eval = -4 * lerpValue * (lerpValue - 1);
        return eval * maxForce;
    }
}