using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            ModifiedState modified = new ModifiedState();
            modified.DoAction(context);

            DeletedState deletedState = new DeletedState();
            deletedState.DoAction(context);

            Console.WriteLine(context.GetState());
            Console.ReadKey();
        }
    }
    interface IState
    {
        void DoAction(Context context);
    }
    class Context
    {
        IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }
        public IState GetState() => _state;
    }
    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Modified");
            context.SetState(this);
        }
    }
    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Deleted");
            context.SetState(this);
        }
    }
    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Added");
            context.SetState(this);
        }
    }
}
