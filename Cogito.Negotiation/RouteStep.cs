namespace Cogito.Negotiation
{

    /// <summary>
    /// Describes a step in a negotiated route.
    /// </summary>
    public class RouteStep
    {

        readonly IExecutable executable;
        readonly double distance;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="executable"></param>
        /// <param name="distance"></param>
        public RouteStep(IExecutable executable, double distance)
        {
            this.executable = executable;
            this.distance = distance;
        }
        
        /// <summary>
        /// Gets the <see cref="IExecutable"/> is responsible for this step.
        /// </summary>
        public IExecutable Executable
        {
            get { return executable; }
        }

        /// <summary>
        /// Gets the negotiated distance between the head and tail negotiators.
        /// </summary>
        public double Distance
        {
            get { return distance; }
        }

    }

}
