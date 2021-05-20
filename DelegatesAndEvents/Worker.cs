using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    public delegate int WorkPerformedHandler(int hours, WorkType workType);

    public class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {

            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i + 1, workType);
            }

            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //if (WorkPerformed != null)
            //{
            //    WorkPerformed(hours, workType);
            //}

            //var del = WorkPerformed as WorkPerformedHandler;
            //if (del != null)
            //{
            //    del(hours, workType);
            //}

            (WorkPerformed as WorkPerformedHandler)?.Invoke(hours, workType);
        }

        protected virtual void OnWorkCompleted()
        {
            //if (WorkCompleted != null)
            //{
            //    WorkCompleted(this, EventArgs.Empty);
            //}

            (WorkCompleted as EventHandler)?.Invoke(this, EventArgs.Empty);
        }
    }
}
