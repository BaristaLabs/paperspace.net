namespace Paperspace
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [Serializable]
    [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors",
        Justification = "These exceptions are specific to the Paperspace API and not general purpose exceptions")]
    public class PaperspaceException : Exception
    {
        /// <summary>
        /// Constructs an instance of PaperspaceException
        /// </summary>
        /// <param name="response">The HttpResponseMessage</param>
        public PaperspaceException(PaperspaceError error)
            : this(error, null)
        {
        }

        public PaperspaceException(PaperspaceError error, Exception innerException)
            : base(error.Message, innerException)
        {
            Ensure.ArgumentNotNull(error, nameof(error));

            Error = error;
        }

        public PaperspaceError Error
        {
            get;
        }

        /// <summary>
        /// The name associated with the error
        /// </summary>
        public string Name
        {
            get { return Error.Name; }
        }

        /// <summary>
        /// The HTTP status code associated with the error
        /// </summary>
        public int StatusCode
        {
            get { return Error.Status; }
        }

        public override string ToString()
        {
            var original = base.ToString();
            return $"{Name} ({StatusCode}): {base.ToString()}";
        }
    }
}
