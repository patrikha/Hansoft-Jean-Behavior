using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;
using System.Xml;

using HPMSdk;

namespace Hansoft.Jean.Behavior
{
    /// <summary>
    /// EventArgs subclass for Hansoft TaskChange events
    /// </summary>
    public class TaskChangeEventArgs : EventArgs
    {
        private HPMChangeCallbackData_TaskChange data;

        internal TaskChangeEventArgs(HPMChangeCallbackData_TaskChange data)
        {
            this.data = data;
        }

        /// <summary>
        /// The detailed event data.
        /// </summary>
        public HPMChangeCallbackData_TaskChange Data { get { return data; } }
    }

    /// <summary>
    /// EventArgs subclass for Hansoft TaskChangeCustomColumnData events
    /// </summary>
    public class TaskChangeCustomColumnDataEventArgs : EventArgs
    {
        private HPMChangeCallbackData_TaskChangeCustomColumnData data;

        internal TaskChangeCustomColumnDataEventArgs(HPMChangeCallbackData_TaskChangeCustomColumnData data)
        {
            this.data = data;
        }

        /// <summary>
        /// The detailed event data.
        /// </summary>
        public HPMChangeCallbackData_TaskChangeCustomColumnData Data { get { return data; } }
    }

    /// <summary>
    /// EventArgs subclass for Hansoft TaskChangeDisposition events
    /// </summary>
    public class TaskMoveEventArgs : EventArgs
    {
        private HPMChangeCallbackData_TaskChangeDisposition data;

        internal TaskMoveEventArgs(HPMChangeCallbackData_TaskChangeDisposition data)
        {
            this.data = data;
        }

        /// <summary>
        /// The detailed event data.
        /// </summary>
        public HPMChangeCallbackData_TaskChangeDisposition Data { get { return data; } }
    }

    /// <summary>
    /// EventArgs subclass for Hansoft DataHistoryReceived events
    /// </summary>
    public class DataHistoryReceivedEventArgs : EventArgs
    {
        private HPMChangeCallbackData_DataHistoryReceived data;

        internal DataHistoryReceivedEventArgs(HPMChangeCallbackData_DataHistoryReceived data)
        {
            this.data = data;
        }

        /// <summary>
        /// The detailed event data.
        /// </summary>
        public HPMChangeCallbackData_DataHistoryReceived Data { get { return data; } }
    }
    
    /// <summary>
    /// EventArgs subclass for Hansoft ProjectCreate events
    /// </summary>
    public class ProjectCreateEventArgs : EventArgs
    {
        private HPMChangeCallbackData_ProjectCreate data;

        internal ProjectCreateEventArgs(HPMChangeCallbackData_ProjectCreate data)
        {
            this.data = data;
        }

        /// <summary>
        /// The detailed event data.
        /// </summary>
        public HPMChangeCallbackData_ProjectCreate Data { get { return data; } }
    }

    /// <summary>
    /// EventArgs subclass for Hansoft TaskCreate events
    /// </summary>
    public class TaskCreateEventArgs : EventArgs
    {
        private HPMChangeCallbackData_TaskCreateUnified data;

        internal TaskCreateEventArgs(HPMChangeCallbackData_TaskCreateUnified data)
        {
            this.data = data;
        }

        /// <summary>
        /// The detailed event data.
        /// </summary>
        public HPMChangeCallbackData_TaskCreateUnified Data { get { return data; } }
    }

    /// <summary>
    /// EventArgs subclass for Hansoft TaskDelete events
    /// </summary>
    public class TaskDeleteEventArgs : EventArgs
    {
        private HPMChangeCallbackData_TaskDelete data;

        internal TaskDeleteEventArgs(HPMChangeCallbackData_TaskDelete data)
        {
            this.data = data;
        }

        /// <summary>
        /// The detailed event data.
        /// </summary>
        public HPMChangeCallbackData_TaskDelete Data { get { return data; } }
    }

    /// <summary>
    /// EventArgs subclass for Hansoft ProcessError events
    /// </summary>
    public class ProcessErrorEventArgs : EventArgs
    {
        private EHPMError error;

        internal ProcessErrorEventArgs(EHPMError error)
        {
            this.error = error;
        }

        /// <summary>
        /// The detailed event data.
        /// </summary>
        public EHPMError Error { get { return error; } }
    }

    /// <summary>
    /// This class is internal to the Jean for Hansoft framework and should not be instantiated directly.
    /// </summary>
    public class HPMCallbackHandler : HPMSdkCallbacks, IDisposable
    {
        /// <summary>
        /// This event handler is internal to the Jean for Hansoft framework and you should not hook up to it directly.
        /// To handle events you should create a subclass of AbstractBehvaior and override the relevant handling methods.
        /// </summary>
        public event EventHandler<TaskChangeEventArgs> TaskChange;

        /// <summary>
        /// This event handler is internal to the Jean for Hansoft framework and you should not hook up to it directly.
        /// To handle events you should create a subclass of AbstractBehvaior and override the relevant handling methods.
        /// </summary>
        public event EventHandler<TaskChangeCustomColumnDataEventArgs> TaskChangeCustomColumnData;

        /// <summary>
        /// This event handler is internal to the Jean for Hansoft framework and you should not hook up to it directly.
        /// To handle events you should create a subclass of AbstractBehvaior and override the relevant handling methods.
        /// </summary>
        public event EventHandler<TaskCreateEventArgs> TaskCreate;

        /// <summary>
        /// This event handler is internal to the Jean for Hansoft framework and you should not hook up to it directly.
        /// To handle events you should create a subclass of AbstractBehvaior and override the relevant handling methods.
        /// </summary>
        public event EventHandler<TaskDeleteEventArgs> TaskDelete;

        /// <summary>
        /// This event handler is internal to the Jean for Hansoft framework and you should not hook up to it directly.
        /// To handle events you should create a subclass of AbstractBehvaior and override the relevant handling methods.
        /// </summary>
        public event EventHandler<TaskMoveEventArgs> TaskMove;

        /// <summary>
        /// This event handler is internal to the Jean for Hansoft framework and you should not hook up to it directly.
        /// To handle events you should create a subclass of AbstractBehvaior and override the relevant handling methods.
        /// </summary>
        public event EventHandler<ProjectCreateEventArgs> ProjectCreate;

        /// <summary>
        /// This event handler is internal to the Jean for Hansoft framework and you should not hook up to it directly.
        /// To handle events you should create a subclass of AbstractBehvaior and override the relevant handling methods.
        /// </summary>
        public event EventHandler<EventArgs> ProjectCreateCompleted;

        /// <summary>
        /// This event handler is internal to the Jean for Hansoft framework and you should not hook up to it directly.
        /// To handle events you should create a subclass of AbstractBehvaior and override the relevant handling methods.
        /// </summary>
        public event EventHandler<DataHistoryReceivedEventArgs> DataHistoryReceived;

        /// <summary>
        /// This event handler is internal to the Jean for Hansoft framework and you should not hook up to it directly.
        /// To handle events you should create a subclass of AbstractBehvaior and override the relevant handling methods.
        /// </summary>
        public event EventHandler<ProcessErrorEventArgs> ProcessError;

        /// <summary>
        /// This event handler is internal to the Jean for Hansoft framework and you should not hook up to it directly.
        /// To handle events you should create a subclass of AbstractBehvaior and override the relevant handling methods.
        /// </summary>
        public event EventHandler<EventArgs> BeginProcessBufferedEvents;

        /// <summary>
        /// This event handler is internal to the Jean for Hansoft framework and you should not hook up to it directly.
        /// To handle events you should create a subclass of AbstractBehvaior and override the relevant handling methods.
        /// </summary>
        public event EventHandler<EventArgs> EndProcessBufferedEvents;

        private System.Timers.Timer windowTimer;
        private int eventWindow;
        private List<EventArgs> eventBuffer;

        /// <summary>
        /// This constructor is internal to the Jean for Hansoft framework and should not be invoked directly.
        /// </summary>
        /// <param name="eventWindow"></param>
        public HPMCallbackHandler(int eventWindow)
        {
            this.eventWindow = eventWindow;
            if (BufferEvents)
            {
                eventBuffer = new List<EventArgs>();
                windowTimer = new System.Timers.Timer(eventWindow) { AutoReset = true };
                windowTimer.Elapsed += (sender, eventArgs) => ProcessBufferedEvents();
                windowTimer.Start();
            }
        }

        private void ProcessBufferedEvents()
        {
            lock (eventBuffer)
            {
                if (eventBuffer.Count > 0)
                {
                    if (BeginProcessBufferedEvents != null)
                        BeginProcessBufferedEvents(this, EventArgs.Empty);
                    for (int i = 0; i < eventBuffer.Count; i += 1)
                    {
                        EventArgs e = eventBuffer[i];
                        if (e is TaskCreateEventArgs)
                        {
                            if (TaskCreate != null)
                                TaskCreate(this, (TaskCreateEventArgs)e);
                        }
                        else if (e is TaskChangeEventArgs)
                        {
                            if (TaskChange != null)
                                TaskChange(this, (TaskChangeEventArgs)e);
                        }
                        else if (e is TaskChangeCustomColumnDataEventArgs)
                        {
                            if (TaskChangeCustomColumnData != null)
                                TaskChangeCustomColumnData(this, (TaskChangeCustomColumnDataEventArgs)e);
                        }
                        else if (e is TaskDeleteEventArgs)
                        {
                            if (TaskDelete != null)
                                TaskDelete(this, (TaskDeleteEventArgs)e);
                        }
                        else if (e is TaskMoveEventArgs)
                        {
                            if (TaskMove != null)
                                TaskMove(this, (TaskMoveEventArgs)e);
                        }
                        else if (e is ProjectCreateEventArgs)
                        {
                            if (ProjectCreate != null)
                                ProjectCreate(this, (ProjectCreateEventArgs)e);
                            if (ProjectCreateCompleted != null)
                                ProjectCreateCompleted(this, new EventArgs());
                        }
                        else if (e is DataHistoryReceivedEventArgs)
                        {
                            if (DataHistoryReceived != null)
                                DataHistoryReceived(this, (DataHistoryReceivedEventArgs)e);
                        }
                    }
                    if (EndProcessBufferedEvents != null)
                        EndProcessBufferedEvents(this, EventArgs.Empty);
                    eventBuffer.Clear();
                }
            }
        }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        public void Dispose()
        {
            if (BufferEvents)
            {
                windowTimer.Stop();
                eventBuffer.Clear();
            }
        }

        /// <summary>
        /// Indicates whether Jean for Hansoft is set up to buffer events or not.
        /// </summary>
        public bool BufferEvents
        {
            get { return eventWindow > 0; }
        }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="_Error"></param>
        public override void On_ProcessError(EHPMError _Error)
        {
            if (ProcessError != null)
                ProcessError(this, new ProcessErrorEventArgs(_Error));
        }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="_Data">The detailed information of the change.</param>
        public override void On_TaskChangeCustomColumnData(HPMChangeCallbackData_TaskChangeCustomColumnData _Data)
        {
            base.On_TaskChangeCustomColumnData(_Data);
            if (BufferEvents)
            {
                lock (eventBuffer)
                {
                    eventBuffer.Add(new TaskChangeCustomColumnDataEventArgs(_Data));
                }
            }
            else
            {
                if (TaskChangeCustomColumnData != null)
                    TaskChangeCustomColumnData(this, new TaskChangeCustomColumnDataEventArgs(_Data));
            }
        }

        private bool IgnoredField(EHPMTaskField field)
        {
            switch (field)
            {
                case (EHPMTaskField.Archived):
                case (EHPMTaskField.AttachedDocuments):
                case (EHPMTaskField.Color):
                case (EHPMTaskField.CommentsOptions):
                case (EHPMTaskField.Container):
                case (EHPMTaskField.CreatedFromWorkflowObject):
                case (EHPMTaskField.CreatedPipelineTasks):
                case (EHPMTaskField.CustomColumnData):
                case (EHPMTaskField.DefaultWorkflow):
                case (EHPMTaskField.DelegateTo):
                case (EHPMTaskField.ForceSubProject):
                case (EHPMTaskField.FullyCreated):
                case (EHPMTaskField.ID):
                case (EHPMTaskField.IdealDaysHistory):
                case (EHPMTaskField.LastUpdatedTime):
                case (EHPMTaskField.LastUserInterfaceAction):
                case (EHPMTaskField.LinkedToPipelineTask):
                case (EHPMTaskField.LockedBy):
                case (EHPMTaskField.LockedType):
                case (EHPMTaskField.NewVersionOfSDKRequired):
                case (EHPMTaskField.OriginallyCreatedBy):
                case (EHPMTaskField.PointsHistory):
                case (EHPMTaskField.SprintResourcesHaveFullRights):
                case (EHPMTaskField.Undefined):
                case (EHPMTaskField.Unlocked):
                case (EHPMTaskField.VacationOptions):
                case (EHPMTaskField.WallItemColor):
                case (EHPMTaskField.WallItemPositions):
                case (EHPMTaskField.VisibleTo):
                case (EHPMTaskField.WorkRemainingHistory):
                    return true;
                default:
                    return false;
            }
        }

        /*
        public override void On_VersionControlSyncFilesResponse(HPMChangeCallbackData_VersionControlSyncFilesResponse _Data)
        {
            base.On_VersionControlSyncFilesResponse(_Data);
        }
        */

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="_Data">The detailed information of the change.</param>
        public override void On_ProjectCreate(HPMChangeCallbackData_ProjectCreate _Data)
        {
            base.On_ProjectCreate(_Data);
            if (BufferEvents)
            {
                lock (eventBuffer)
                {
                    eventBuffer.Add(new ProjectCreateEventArgs(_Data));
                }
            }
            else
            {
                if (ProjectCreate != null)
                    ProjectCreate(this, new ProjectCreateEventArgs(_Data));
                if (ProjectCreateCompleted != null)
                    ProjectCreateCompleted(this, new EventArgs());
            }
        }


        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="_Data">The detailed information of the change.</param>
        public override void On_TaskChange(HPMChangeCallbackData_TaskChange _Data)
        {
            base.On_TaskChange(_Data);
            if (!IgnoredField(_Data.m_FieldChanged))
            {
                if (BufferEvents)
                {
                    lock (eventBuffer)
                    {
                        eventBuffer.Add(new TaskChangeEventArgs(_Data));
                    }
                }
                else
                {
                    if (TaskChange != null)
                        TaskChange(this, new TaskChangeEventArgs(_Data));
                }
            }
        }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="_Data">The detailed information of the change.</param>
        public override void On_TaskChangeDisposition(HPMChangeCallbackData_TaskChangeDisposition _Data)
        {
            base.On_TaskChangeDisposition(_Data);
            if (BufferEvents)
            {
                lock (eventBuffer)
                {
                    eventBuffer.Add(new TaskMoveEventArgs(_Data));
                }
            }
            else
            {
                if (TaskMove != null)
                    TaskMove(this, new TaskMoveEventArgs(_Data));
            }
        }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="_Data">The detailed information of the change.</param>
        public override void On_DataHistoryReceived(HPMChangeCallbackData_DataHistoryReceived _Data)
        {
            base.On_DataHistoryReceived(_Data);
            if (BufferEvents)
            {
                lock (eventBuffer)
                {
                    eventBuffer.Add(new DataHistoryReceivedEventArgs(_Data));
                }
            }
            else
            {
                if (DataHistoryReceived != null)
                    DataHistoryReceived(this, new DataHistoryReceivedEventArgs(_Data));
            }
        }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="_Data">The detailed information of the change.</param>
        public override void On_TaskCreateUnified(HPMChangeCallbackData_TaskCreateUnified _Data)
        {
            base.On_TaskCreateUnified(_Data);
            if (BufferEvents)
            {
                lock (eventBuffer)
                {
                    eventBuffer.Add(new TaskCreateEventArgs(_Data));
                }
            }
            else
            {
                if (TaskCreate != null)
                    TaskCreate(this, new TaskCreateEventArgs(_Data));
            }
        }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="_Data">The detailed information of the change.</param>
        public override void On_TaskDelete(HPMChangeCallbackData_TaskDelete _Data)
        {
            base.On_TaskDelete(_Data);
            if (BufferEvents)
            {
                lock (eventBuffer)
                {
                    eventBuffer.Add(new TaskDeleteEventArgs(_Data));
                }
            }
            else
            {
                if (TaskDelete != null)
                    TaskDelete(this, new TaskDeleteEventArgs(_Data));
            }
        }
    }
}
