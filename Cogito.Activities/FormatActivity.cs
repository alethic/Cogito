using System;
using System.Activities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Cogito.Linq;

namespace Cogito.Activities
{

    /// <summary>
    /// Implements a <see cref="string.Format(string, object[])"/> invocation.
    /// </summary>
    public class FormatActivity :
        NativeActivity<string>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FormatActivity()
        {
            Arguments = new Collection<InArgument<object>>();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        public FormatActivity(InArgument<string> format)
            : this()
        {
            Format = format;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public FormatActivity(InArgument<string> format, params InArgument<object>[] args)
            : this(format)
        {
            foreach (var i in args)
                Arguments.Add(i);
        }

        /// <summary>
        /// String to be formatted.
        /// </summary>
        [RequiredArgument]
        public InArgument<string> Format { get; set; }

        /// <summary>
        /// Arguments to format string with.
        /// </summary>
        [RequiredArgument]
        public ICollection<InArgument<object>> Arguments { get; set; }
        
        /// <summary>
        /// Creates and validates a description of the activity's arguments.
        /// </summary>
        /// <param name="metadata"></param>
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            // bind arguments collection
            Arguments
                .Select((i, j) => Tuple.Create(i, new RuntimeArgument($"Arg{j}", typeof(object), ArgumentDirection.In)))
                .ForEach(i =>
                {
                    metadata.Bind(i.Item1, i.Item2);
                    metadata.AddArgument(i.Item2);
                });
        }

        /// <summary>
        /// Executes the activity.
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(NativeActivityContext context)
        {
            context.SetValue(Result, string.Format(context.GetValue(Format), Arguments.Select(i => context.GetValue(i)).ToArray()));
        }

    }

}
