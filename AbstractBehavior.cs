using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using HPMSdk;
using Hansoft.SimpleLogging;

namespace Hansoft.Jean.Behavior
{
    /// <summary>
    /// The base class for behaviors that should be automated by Jean for Hansoft. A behavior is notified of changes in Hansoft
    /// by overriding the suitable event handlers in this base class and then making updates to Hansoft or take other actions
    /// as required. To add a behavior to Jean you need to do the following
    /// 1. Realize the behavior as a subclass of AbstractBehavior. The class and the dll should have the same name as your
    ///    behavior, e.g., MyCustomBehavior.
    /// 2. Add the behavior to the directory where Jean.exe is found
    /// 3. Add your behavior dll to the LoadAssemblies section in JeanSettings.xml
    /// 4. Instantiate your behavior by adding a behavior element with any needed parameters to JeanSettings.xml
    ///    (See the provided examples for details).
    /// </summary>
    public abstract class AbstractBehavior
    {
        XmlElement configuration;
        bool bufferedEvents;
        bool initialized;
        List<string> extensionAssemblies;
        ILogger logger;

        /// <summary>
        /// General constructor. Should be called by subclasses.
        /// </summary>
        /// <param name="configuration">The XmlElement that contains the configuration parameters for the behavior.</param>
        public AbstractBehavior(XmlElement configuration)
        {
            this.configuration = configuration;
            this.initialized = false;
        }

        /// <summary>
        /// Subclasses should return a descriptive string of the behavior instance used, e.g., for debugging/tracing.
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// Returns the value of the specified XmlAttribute from the configuration XmlElement.
        /// </summary>
        /// <param name="parameterName">Name of the requested XmlAttribure.</param>
        /// <returns>The value of the XmlAttribute if it exists. Otherwise string.Empty is returned.</returns>
        public string GetParameter(string parameterName)
        {
            if (configuration.HasAttribute(parameterName))
            {
                return configuration.GetAttribute(parameterName).Replace('\'', '"');
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// This method is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="bufferedEvents">Indicates whether events should be buffered or not.</param>
        /// <param name="extensionAssemblies">A list of paths for the assemblies that have been loaded in the LoadAssemblies section of JeanSettings.xml</param>
        /// <param name="logger">The logging service instance to be used.</param>
        public void Initialize(bool bufferedEvents, List<string> extensionAssemblies, ILogger logger)
        {
            this.logger = logger;
            this.bufferedEvents = bufferedEvents;
            this.extensionAssemblies = extensionAssemblies;
            initialized = false;
            Initialize();
            initialized = true;
        }

        /// <summary>
        /// Subclass responsibility, should throw an exception if initialization fails in some way.
        /// </summary>
        /// <returns></returns>
        public abstract void Initialize();

        /// <summary>
        /// Indicates whether the behavior has been succesfully initialized or not. You should not set this explicitly as it
        /// is handled by the Jean for Hansoft framework.
        /// </summary>
        public bool Initialized
        {
            get{ return initialized; }
            set { initialized = value;}
        }

        /// <summary>
        /// The logger that this behavior uses to log messages.
        /// </summary>
        public ILogger Logger
        {
            get { return logger; }
        }

        /// <summary>
        /// Indicates whether Jean for Hansoft is currently buffering events as specified with the EventWindow attribute of the Connection element in JeanSettings.xml
        /// </summary>
        public bool BufferedEvents
        {
            get { return bufferedEvents; }
        }

        /// <summary>
        /// The list of paths for the assemblies that have been loaded in the LoadAssemblies section of JeanSettings.xml
        /// </summary>
        public List<string> ExtensionAssemblies
        {
            get { return extensionAssemblies; }
        }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnTaskChange(object sender, TaskChangeEventArgs e)
        {
            try
            {
                OnTaskChange(e);
            }
            catch (Exception ex)
            {
                logger.Exception("Error proccessing TaskChangeEvent for behavior " + Title + ".", ex);
            }
        }

        /// <summary>
        /// Override this function in subclasses to handle TaskChange events.
        /// </summary>
        /// <param name="e">The details of the event.</param>
        public virtual void OnTaskChange(TaskChangeEventArgs e) { }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnTaskChangeCustomColumnData(object sender, TaskChangeCustomColumnDataEventArgs e)
        {
            try
            {
                OnTaskChangeCustomColumnData(e);
            }
            catch (Exception ex)
            {
                logger.Exception("Error proccessing TaskChangeCustomColumnData for behavior " + Title + ".", ex);
            }
        }

        /// <summary>
        /// Override this function in subclasses to handle TaskChangeCustomColumnData events.
        /// </summary>
        /// <param name="e">The details of the event.</param>
        public virtual void OnTaskChangeCustomColumnData(TaskChangeCustomColumnDataEventArgs e) { }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnTaskMove(object sender, TaskMoveEventArgs e)
        {
            try
            {
                OnTaskMove(e);
            }
            catch (Exception ex)
            {
                logger.Exception("Error proccessing TaskMove for behavior " + Title + ".", ex);
            }
        }

        /// <summary>
        /// Override this function in subclasses to handle TaskMove events.
        /// </summary>
        /// <param name="e">The details of the event.</param>
        public virtual void OnTaskMove(TaskMoveEventArgs e) { }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnDataHistoryReceived(object sender, DataHistoryReceivedEventArgs e)
        {
            try
            {
                OnDataHistoryReceived(e);
            }
            catch (Exception ex)
            {
                logger.Exception("Error proccessing DataHistoryReceived for behavior " + Title + ".", ex);
            }
        }

        /// <summary>
        /// Override this function in subclasses to handle DataHistoryReceived events.
        /// </summary>
        /// <param name="e">The details of the event.</param>
        public virtual void OnDataHistoryReceived(DataHistoryReceivedEventArgs e) { }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnProjectCreate(object sender, ProjectCreateEventArgs e)
        {
            try
            {
                OnProjectCreate(e);
            }
            catch (Exception ex)
            {
                logger.Exception("Error proccessing ProjectCreate for behavior " + Title + ".", ex);
            }
        }

        /// <summary>
        /// Override this function in subclasses to handle ProjectCreate events.
        /// </summary>
        /// <param name="e">The details of the event.</param>
        public virtual void OnProjectCreate(ProjectCreateEventArgs e) { }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnTaskDelete(object sender, TaskDeleteEventArgs e)
        {
            try
            {
                OnTaskDelete(e);
            }
            catch (Exception ex)
            {
                logger.Exception("Error proccessing TaskDelete for behavior " + Title + ".", ex);
            }
        }

        /// <summary>
        /// Override this function in subclasses to handle TaskDelete events.
        /// </summary>
        /// <param name="e">The details of the event.</param>
        public virtual void OnTaskDelete(TaskDeleteEventArgs e) { }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnTaskCreate(object sender, TaskCreateEventArgs e)
        {
            try
            {
                OnTaskCreate(e);
            }
            catch (Exception ex)
            {
                logger.Exception("Error proccessing TaskCreateEvent for behavior " + Title + ".", ex);
            }
        }

        /// <summary>
        /// Override this function in subclasses to handle TaskCreate events.
        /// </summary>
        /// <param name="e">The details of the event.</param>
        public virtual void OnTaskCreate(TaskCreateEventArgs e) { }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnBeginProcessBufferedEvents(object sender, EventArgs e)
        {
            try
            {
                OnBeginProcessBufferedEvents(e);
            }
            catch (Exception ex)
            {
                logger.Exception("Error proccessing BeginProcessBufferedEventsEvent for behavior " + Title + ".", ex);
            }
        }

        /// <summary>
        /// Override this function in subclasses to insert behavior before the processing of 
        /// buffered events. This is only applicable if Jean for Hansoft is set up to use event buffering.
        /// </summary>
        /// <param name="e">The details of the event.</param>
        public virtual void OnBeginProcessBufferedEvents(EventArgs e) { }

        /// <summary>
        /// This function is internal to the Jean for Hansoft framework and should not be called directly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnEndProcessBufferedEvents(object sender, EventArgs e)
        {
            try
            {
                OnEndProcessBufferedEvents(e);
            }
            catch (Exception ex)
            {
                logger.Exception("Error proccessing EndProcessBufferedEventsEvent for behavior " + Title + ".", ex);
            }
        }

        /// <summary>
        /// Override this function in subclasses to insert behavior after the processing of 
        /// buffered events. This is only applicable if Jean for Hansoft is set up to use event buffering.
        /// </summary>
        /// <param name="e">The details of the event.</param>
        public virtual void OnEndProcessBufferedEvents(EventArgs e) { }
    }
}
