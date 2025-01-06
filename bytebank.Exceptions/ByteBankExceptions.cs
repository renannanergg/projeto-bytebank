namespace bytebank.Exceptions;

[Serializable]
public class ByteBankException : System.Exception
{
    public ByteBankException() { }
    public ByteBankException(string message) : base("Aconteceu a seguinte exceção ->" + message) { }
    public ByteBankException(string message, Exception inner) : base(message, inner) { }
    protected ByteBankException(
        System.Runtime.Serialization.SerializationInfo info,
#pragma warning disable SYSLIB0051 // Type or member is obsolete
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
#pragma warning restore SYSLIB0051 // Type or member is obsolete
}