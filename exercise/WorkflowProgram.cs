using System;
using System.Collections.Generic;

namespace ExercisePolymorphism
{
    public interface ITask
    {
        void Execute();
    }

    public interface IWorkflow
    {
        void Add(ITask task);
        void Remove(ITask task);
        IEnumerable<ITask> GetTasks();
    }
    public class Workflow : IWorkflow
    {
        private readonly List<ITask> _tasks;

        public Workflow()
        {
            _tasks = new List<ITask>();
        }
        public void Add(ITask activity)
        {
            _tasks.Add(activity);
        }

        public void Remove(ITask activity)
        {
            _tasks.Remove(activity);
        }

        public IEnumerable<ITask> GetTasks()
        {
            return _tasks;
        }
    }

    public class WorkflowEngine
    {
        public void Run(IWorkflow workflow)
        {
            foreach (ITask task in workflow.GetTasks())
            {
                try
                {
                    task.Execute();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    public class UploadVideo : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Upload video");
        }
    }
    public class EncodeVideo : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Encode video");
        }
    }
    public class NotifyVideo : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Notify video");
        }
    }

    public class UpdateVideo : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Update video");
        }
    }

    class WorkflowProgram
    {
        public static void Main(string[] args)
        {
            var workflow = new Workflow();

            workflow.Add(new UploadVideo());
            workflow.Add(new EncodeVideo());
            workflow.Add(new NotifyVideo());
            workflow.Add(new UpdateVideo());

            var engine = new WorkflowEngine();
            engine.Run(workflow);
        }
    }
}