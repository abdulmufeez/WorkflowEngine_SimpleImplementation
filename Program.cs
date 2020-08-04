using System;

namespace WorkFlowEngine_SimpleModel
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new WorkFlowEngine();
            WorkFlow workflow = new WorkFlow();
            workflow.AddWorkFlow(new UploadingVideo());         //adding tasks in worflow
            workflow.AddWorkFlow(new CallingWebService());
            workflow.AddWorkFlow(new SendingMail());
            workflow.AddWorkFlow(new ChangingStatus());
            engine.Run(workflow);
        }
    }
}
