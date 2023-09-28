using Pulsar4X.DataStructures;

namespace Pulsar4X.Engine.Orders
{
    public class ConditionalOrder
    {
        public string Name { get; set; }
        public CompoundCondition Condition { get; }
        public SafeList<EntityCommand> Actions { get; }

        public bool IsValid
        {
            get
            {
                return Condition != null && Actions != null;
            }
        }

        public ConditionalOrder()
        {
            Condition = new CompoundCondition();
            Actions = new ();
        }

        public ConditionalOrder(CompoundCondition condition, SafeList<EntityCommand> actions)
        {
            Condition = condition;
            Actions = actions;
        }
    }
}