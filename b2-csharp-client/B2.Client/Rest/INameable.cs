namespace B2.Client.Rest
{
    /// <summary>
    /// Indicates the object has a named string property.
    /// </summary>
    public interface INameable
    {
        /// <summary>
        /// The simple string name of the object.
        /// </summary>
        string Name { get; }
    }
}