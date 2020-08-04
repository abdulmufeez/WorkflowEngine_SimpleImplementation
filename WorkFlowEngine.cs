using System;
using System.Collections.Generic;
using System.Text;

namespace WorkFlowEngine_SimpleModel
{ 
    public class WorkFlowEngine                //Actual Workflow Engine in which worklow is present
    {
        public void Run(IWorkFlow workflow)    //Run workflow present in engine
        {

            foreach (var task in workflow.GetType())
            {
                task.Execute();
            }
        }
    }
    public interface IWorkFlow                 //A workflow is a series of steps or activities or tasks
    {
        void AddWorkFlow(ITask task);          //these are methods to add/remove steps or task in current workflow
        void RemoveWorkFlow(ITask task);
        IEnumerable<ITask> GetType();           //this method is use so that anyone cant see the actual list of used below
    }
    public class WorkFlow : IWorkFlow
    {
        private readonly List<ITask> tasks;     //list to stores task objects
        public WorkFlow()
        {
            tasks = new List<ITask>();
        }
        public void AddWorkFlow(ITask task)
        {
            tasks.Add(task);                    //adding task or step objects
        }

        public void RemoveWorkFlow(ITask task)
        {
            tasks.Remove(task);
        }
        public IEnumerable<ITask> GetType()    //use encapsulation so that anyone not use or modifed object list
        {
            return tasks;
        }
    }
    public interface ITask      //Here I make a task interface so that  
    {                           //i can make any change in task written below
        void Execute();         //This is to execute each task
    }
    public class UploadingVideo : ITask
    {
        void ITask.Execute()
        {
            //some logics
            Console.WriteLine("Uploading Video To the Cloud");
        }
    }
    public class CallingWebService : ITask
    {
        public void Execute()
        {
            ////some logics
            Console.WriteLine("Call a web service provided by a " +
                "third-party video encoding service to tell them" +
                " you have a video ready for encoding.");
        }
    }
    public class SendingMail : ITask
    {
        public void Execute()
        {
            //some logics
            Console.WriteLine("Send an email to the owner of the video" +
                " notifying them that the video started processing.");
        }
    }
    public class ChangingStatus : ITask
    {
        public void Execute()
        {
            //some logics
            Console.WriteLine("Change the status of the video record in the database to “Processing”.");
        }
    }
}
