namespace Cogito.Negotiation.Tests.Negotiators
{

    public abstract class State
    {

        readonly string value;

        protected State(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return value; }
        }

    }

}
