public class ForwardControl
{
    public float Move(float speed)
    {
        return speed + GlobalVariables.TopSpeed;
    }
}