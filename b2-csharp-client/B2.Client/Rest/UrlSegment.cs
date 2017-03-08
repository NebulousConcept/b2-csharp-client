using System;
using System.Collections.Generic;
using System.Linq;

using B2.Client.Rest.Request.Param;


namespace B2.Client.Rest
{
    /// <summary>
    /// A class representing a URL segment. Parameter segments represent a request URL parameter and can be 
    /// transformed into the appropriate parameter value.
    /// </summary>
    public abstract class UrlSegment
    {
        /// <summary>
        /// The 'b2api' literal.
        /// </summary>
        public static readonly UrlSegment B2Api = Literal("b2api");

        /// <summary>
        /// The 'v1' literal.
        /// </summary>
        public static readonly UrlSegment V1 = Literal("v1");


        private UrlSegment() { }

        /// <summary>
        /// Transform this segment according to the specified parameters and this segment's transformation rules.
        /// </summary>
        /// <param name="parameters">The parameters to use to transform the segment.</param>
        /// <returns>The transformed segment, as a string.</returns>
        public abstract string Transform(IEnumerable<RestParam> parameters);

        /// <summary>
        /// Create a new Literal segment.
        /// </summary>
        /// <param name="segment">The string representation of the segment.</param>
        /// <returns>A literal segment encapsulating the string.</returns>
        public static UrlSegment Literal(string segment) => new LiteralSegment(segment);

        /// <summary>
        /// Create a new Parameter segment.
        /// </summary>
        /// <param name="paramName">The parameter name.</param>
        /// <returns>A parameter segment encapsulating the parameter</returns>
        public static UrlSegment Parameter(string paramName) => new ParameterSegment(paramName);

        private class LiteralSegment : UrlSegment
        {
            private readonly string segment;

            public LiteralSegment(string value)
            {
                segment = value.ThrowIfNull(nameof(value));
            }

            // Literal segments never transform and are simply URI encoded strings
            public override string Transform(IEnumerable<RestParam> parameters) => Uri.EscapeUriString(segment);
        }

        private class ParameterSegment : UrlSegment
        {
            private readonly string paramName;


            public ParameterSegment(string parameterName)
            {
                paramName = parameterName.ThrowIfNull(nameof(parameterName));
            }

            //Parameter segments are converted to the corresponding parameter's value.
            public override string Transform(IEnumerable<RestParam> parameters) =>
                parameters
                .Where(p => p.Name == paramName)
                .Select(p => Uri.EscapeUriString(p.Value))
                .Single();
        }
    }
}
